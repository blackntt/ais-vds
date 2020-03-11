using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace VirusDetectionSystem
{
    public class CleanThreadCell
    {
        private HashSet<BinaryString> cleanedSet;
        public CleanThreadCell()
        {
            cleanedSet = new HashSet<BinaryString>();
        }
        public HashSet<BinaryString> CleanedSet
        {
            get { return cleanedSet; }
            set { cleanedSet = value; }
        }
        public void GlobalCleanXBasedOnY(List<BinaryString> X, HashSet<BinaryString> Y, int matchingThreshold, int threadCount)
        {
            //int threadCount = X.Count / limitCount;
            //if (X.Count % limitCount != 0) threadCount++;
            //int threadCount = 5;
            
            int limitCount=0;
            if (X.Count >= 20)
            {
                limitCount = X.Count / threadCount;
                if (X.Count % threadCount != 0) threadCount++;
            }
            else
            {
                threadCount = 1;
                limitCount = X.Count;
            }
            List<Thread> threads = new List<Thread>();
            List<CleanThreadUnit> units = new List<CleanThreadUnit>();
            for (int i = 0; i < threadCount; i++)
            {
                BinaryString[] tempX = new BinaryString[(i == (threadCount - 1)) ? X.Count - i * limitCount : limitCount];
                X.CopyTo(i * limitCount,tempX,0, tempX.Length);
                CleanThreadUnit cleanUnit = new CleanThreadUnit();
                units.Add(cleanUnit);
                threads.Add(new Thread(delegate() { cleanUnit.CleanXBasedOnY(tempX, Y, matchingThreshold); }));
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
                cleanedSet.UnionWith(units[i].CleanedSet);
            }
        }
    }
    public class CleanThreadUnit
    {
        private HashSet<BinaryString> cleanedSet;

        public HashSet<BinaryString> CleanedSet
        {
            get { return cleanedSet; }
            set { cleanedSet = value; }
        }
        public CleanThreadUnit() { cleanedSet = new HashSet<BinaryString>(); }

        public void CleanXBasedOnY(BinaryString[] X, HashSet<BinaryString> Y, int matchingThreshold)
        {
            cleanedSet = new HashSet<BinaryString>(X);

            //for (int i = 0; i < Y.Count; i++)
            //{
            //    for (int j = 0; j < cleanedSet.Count; )
            //    {

            //        if (MatchingMachine.HammingDisWithThreshold(Y.ElementAt(i), cleanedSet.ElementAt(j), matchingThreshold))
            //        {
            //            cleanedSet.Remove(cleanedSet.ElementAt(j));
            //        }
            //        else
            //            j++;

            //    }
            //}
            foreach (var Yelement in Y)
            {
                for (int j = 0; j < cleanedSet.Count; )
                {
                    if (MatchingMachine.HammingDisWithThreshold(Yelement, cleanedSet.ElementAt(j), matchingThreshold))
                    {
                        cleanedSet.Remove(cleanedSet.ElementAt(j));
                    }
                    else
                        j++;

                }
            }
           

        }
    }
}
