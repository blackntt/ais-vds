using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirusDetectionSystem
{
    public class BinaryString
    {
        /// <summary>
        /// Value of the binary string
        /// </summary>
        bool[] _value=new bool[32];

        /// <summary>
        /// Property of value of the binary string
        /// </summary>
        public bool[] Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Constructor without a parameter
        /// </summary>
        public BinaryString() { }

        /// <summary>
        /// Constructor with value send to value of binary string
        /// </summary>
        /// <param name="value"></param>
        public BinaryString(bool[] value) { _value = value; }

        /// <summary>
        /// Check 2 binary strings equal or not
        /// </summary>
        /// <param name="obj">The para that the binary string compare to</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BinaryString))
                return false;
            else
                return BinaryString.Compare2BinaryString(this, (BinaryString)obj);
        }

        /// <summary>
        /// Return hashcode representing for the binary string
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int d = ToString().GetHashCode();
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Convert binary string to string
        /// </summary>
        /// <returns>String contains '1' or '0', '1' represent for TRUE '0' represent for FALSE</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _value.Length; i++)
            {
                result.Append(_value[i] ? '1' : '0');
            }
            return result.ToString();
        }

        /// <summary>
        /// Compare 2 binary strings are equal or not.
        /// </summary>
        /// <param name="item1">1st binary string</param>
        /// <param name="item2">2nd binary string</param>
        /// <returns>Return TRUE if 2 binary strings are equal, return FALSE if not</returns>
        public static bool Compare2BinaryString(BinaryString item1, BinaryString item2)
        {
            for (int i = 0; i < item1.Value.Length; i++)
            {
                if (!(item1.Value[i]==item2.Value[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
