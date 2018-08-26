using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialsDomain
{
    public static class NumberExtensions
    {
        public static int[] GetIntArray(this int num)
        {
            var listOfInts = new List<int>();

            while(num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            listOfInts.Reverse();
            
            return listOfInts.ToArray();
        }

        public static long[] GetLongArray(this long num)
        {
            var listOfInts = new List<long>();

            while(num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            listOfInts.Reverse();
            
            return listOfInts.ToArray();
        }

        public static int ConcatNumbers(this int[] values)
        {
            return values.Select((t, i) => t * Convert.ToInt32(Math.Pow(10, values.Length - i - 1))).Sum();
        }
    }

}
