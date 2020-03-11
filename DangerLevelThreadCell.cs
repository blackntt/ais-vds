using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace VirusDetectionSystem
{
    public class DangerLevelThreadCell
    {
        private List<LD> dangerLevels;

        public List<LD> DangerLevels
        {
            get { return dangerLevels; }
            set { dangerLevels = value; }
        }
        public DangerLevelThreadCell() { dangerLevels = new List<LD>(); }
        public void ComputingDangerLevels(List<FileInfo> files, HashSet<BinaryString> detectors, int threadCount)
        {
            dangerLevels = new List<LD>();
            int limitCount = 0;
            if (files.Count >= 20)
            {
                limitCount = files.Count / threadCount;
                if (files.Count % threadCount != 0) threadCount++;
            }
            else
            {
                threadCount = 1;
                limitCount = files.Count;
            }

            //int threadCount = files.Count / limitCount;
            //if (files.Count % limitCount != 0) threadCount++;
            List<Thread> threads = new List<Thread>();
            List<DangerLevelThreadUnit> units = new List<DangerLevelThreadUnit>();
            for (int i = 0; i < threadCount; i++)
            {
                FileInfo[] tempX = new FileInfo[(i == (threadCount - 1)) ? files.Count - i * limitCount : limitCount];
                files.CopyTo(i * limitCount, tempX, 0, tempX.Length);
                DangerLevelThreadUnit cleanUnit = new DangerLevelThreadUnit();
                units.Add(cleanUnit);
                threads.Add(new Thread(delegate() { cleanUnit.ComputeDangerLevels(tempX,detectors); }));
            }
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].IsBackground = true;
                threads[i].Start();
            }
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
            }
            for (int i = 0; i < units.Count; i++)
            {
                this.dangerLevels.AddRange(units[i].DangerLevels);
            }
        }
        //public void ComputingDangerLevelsVersion2(List<FileInfo> files, HashSet<BinaryString> detectors, int threadCount)
        //{
        //    foreach (var file in files)
        //    {
                
        //    }
        //}
    }
    public class DangerLevelThreadUnit
    {
        private List<LD> dangerLevels;
        public List<LD> DangerLevels
        {
            get { return dangerLevels; }
            set { dangerLevels = value; }
        }
        public DangerLevelThreadUnit() { dangerLevels = new List<LD>(); }
        public void ComputeDangerLevels(FileInfo[] files, HashSet<BinaryString> detectors)
        {
            for (int i = 0; i < files.Length; i++)
            {
                dangerLevels.Add(ComputeADangerLevel(files[i], detectors));
            }
        }
        private LD ComputeADangerLevel(FileInfo fi, HashSet<BinaryString> detectors)
        {
            HashSet<BinaryString> ldStrSet = new HashSet<BinaryString>();
            byte[] binaryArray = null;
            binaryArray = File.ReadAllBytes(fi.FullName);
            LD ld = new LD();
            ld.FileName = fi.Name;
            for (int i = 0; i < binaryArray.Length / 2 - 4; i++)
            {
                Gene gene = new Gene();
                Array.Copy(binaryArray, i * 2, gene.ByteGene, 0, 4);
                ldStrSet.Add(new BinaryString(gene.ToBools()));
            }
            foreach (BinaryString currGene in ldStrSet)
            {
                LD tempLD = new LD();
                HashSet<BinaryString> relevantDetectors = GetRelevantDetectors(currGene, detectors);
                if (relevantDetectors.Count > 0)
                {
                    foreach (BinaryString detector in relevantDetectors)
                    {
                        tempLD.HA += GetHA(currGene, detector);
                        tempLD.RCBA12 += GetRCBA(currGene, detector, 12);
                        tempLD.RCBA24 += GetRCBA(currGene, detector, 24);
                    }
                    tempLD.HA = tempLD.HA / relevantDetectors.Count;
                    tempLD.RCBA12 = tempLD.RCBA12 / relevantDetectors.Count;
                    tempLD.RCBA24 = tempLD.RCBA24 / relevantDetectors.Count;
                }
                ld.HA += tempLD.HA;
                ld.RCBA12 += tempLD.RCBA12;
                ld.RCBA24 += tempLD.RCBA24;
            }
            ld.HA = ld.HA / ldStrSet.Count;
            ld.RCBA12 = ld.RCBA12 / ldStrSet.Count;
            ld.RCBA24 = ld.RCBA24 / ldStrSet.Count;
            return ld;
        }
        private int GetRCBA(BinaryString currGene, BinaryString detector, int r)
        {
            return GetRCB(currGene, detector, r);
        }
        private double GetHA(BinaryString item1, BinaryString item2)
        {
            return MatchingMachine.GetHammingDis(item1, item2);
        }
        private int GetRCB(BinaryString item1, BinaryString item2, int threshold)
        {
            BinaryString result = new BinaryString(new bool[item1.Value.Length]);
            for (int i = 0; i < item1.Value.Length; i++)
            {
                result.Value[i] = (item1.Value[i] == item2.Value[i]);
            }
            int count = 0;
            int max = 0;
            for (int i = 1; i < result.Value.Length; i++)
            {
                if (result.Value[i])
                    count++;
                else
                {
                    if (count > max)
                        max = count;
                    count = 0;
                }
            }
            if (max >= threshold)
                return 1;
            else
                return 0;
        }
        private HashSet<BinaryString> GetRelevantDetectors(BinaryString currGene, HashSet<BinaryString> detectors)
        {
            return detectors;
        }

    }
}
