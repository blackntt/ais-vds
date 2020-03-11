using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VirusDetectionSystem
{
    public class ComputingAff_DisThreadCell
    {
        List<Detector_Aff> result;

        public List<Detector_Aff> Result
        {
            get { return result; }
            set { result = value; }
        }
        public ComputingAff_DisThreadCell()
        {
            result = new List<Detector_Aff>();
        }
        public void Computing(List<BinaryString> detectorSet, BinaryString sample, int limitCount)
        {
            int threadCount = detectorSet.Count / limitCount;
            if (detectorSet.Count % limitCount != 0) threadCount++;
            List<Thread> threads = new List<Thread>();
            List<ComputingAff_DisThreadUnit> units = new List<ComputingAff_DisThreadUnit>();
            for (int i = 0; i < threadCount; i++)
            {
                BinaryString[] tempX = new BinaryString[(i == (threadCount - 1)) ? detectorSet.Count - i * limitCount : limitCount];
                detectorSet.CopyTo(i * limitCount, tempX, 0, tempX.Length);
                ComputingAff_DisThreadUnit cleanUnit = new ComputingAff_DisThreadUnit();
                units.Add(cleanUnit);
                threads.Add(new Thread(delegate() { cleanUnit.Computing(tempX, sample); }));
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
                this.result.AddRange(units[i].Result);
            }
        }
    }
    public class ComputingAff_DisThreadUnit
    {
        List<Detector_Aff> result;

        public List<Detector_Aff> Result
        {
            get { return result; }
            set { result = value; }
        }

        public ComputingAff_DisThreadUnit()
        {
            result = new List<Detector_Aff>();
        }

        public void Computing(BinaryString[] detectorSet, BinaryString sample)
        {
            for (int i = 0; i < detectorSet.Length; i++)
            {
                Detector_Aff temp = new Detector_Aff() { Detector = detectorSet[i], Sample = sample, Distance = MatchingMachine.GetHammingDis(detectorSet[i], sample) };
                result.Add(temp);
            }
        }

    }
}
