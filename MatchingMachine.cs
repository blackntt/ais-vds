using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirusDetectionSystem
{
    public class MatchingMachine
    {
        public static int GetHammingAff(BinaryString item1, BinaryString item2)
        {
            int count = 0;
            int length = item1.Value.Length;
            for (int i = 0; i < length; i++)
            {
                if (item1.Value[i] == item2.Value[i])
                {
                    count++;
                }
            }
            return count;
        }
        public static int GetHammingDis(BinaryString item1, BinaryString item2)
        {
            return item1.Value.Length- GetHammingAff(item1, item2);
        }
        public static bool HammingDisWithThreshold(BinaryString item1, BinaryString item2,int threshold)
        {
            int dis = GetHammingDis(item1, item2);
            return (dis <= threshold);
        }
    }
}
