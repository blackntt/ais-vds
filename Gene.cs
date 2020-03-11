using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirusDetectionSystem
{
    public class Gene
    {
        byte[] _ByteGene;
        public byte[] ByteGene
        {
            get { return _ByteGene; }
            set { _ByteGene = value; }
        }
        public Gene()
        {
            ByteGene = new byte[4];
        }
        public static bool CompareGene(Gene gene1, Gene gene2)
        {
            for (int i = 0; i < gene1.ByteGene.Length; i++)
            {
                if (gene1.ByteGene[i].CompareTo(gene2.ByteGene[i]) != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < ByteGene.Length; i++)
            {
                result += Convert.ToString(ByteGene[i], 2).PadLeft(8, '0');
            }
            return result;
        }
        public bool[] ToBools()
        {
            string temp=this.ToString();
            bool[] result = new bool[32];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (temp[i]=='1' ? true : false);
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Gene))
                return false;
            else
                return Gene.CompareGene(this, (Gene)obj);
        }
        public override int GetHashCode()
        {
            string result = "";
            for (int i = 0; i < ByteGene.Length; i++)
            {
                result += ByteGene[i].ToString();
            }
            return result.GetHashCode();
        }
    }
}
