using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirusDetectionSystem
{
    public class DetectorGenerator
    {
        Random _rd = new Random();
        public BinaryString GenerateADetector(int length)
        {
            bool[] value = new bool[length];
            for (int i = 0; i < length; i++)
            {
                value[i]= _rd.Next(0, 2)==1;
            }
            return new BinaryString(value);
        }
        public BinaryString GenerateADetector(BinaryString pattern, int m)
        {
            Random rd = new Random();
            int length = pattern.Value.Length;
            bool[] newValue = new bool[pattern.Value.Length];
            pattern.Value.CopyTo(newValue, 0);
            List<int> choices = new List<int>();
            for (int i = 0; i < length; i++)
            {
                choices.Add(i);
            }
            for (int i = 0; i < m; i++)
            {
                int temp = rd.Next(0, choices.Count);
                int index = choices[temp];
                choices.RemoveAt(temp);
                newValue[index] = rd.Next(0, 2) == 1;
            }
            return new BinaryString(newValue);
        }
    }
}
