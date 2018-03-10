using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialsDomain
{
    public struct CapacitanceNumberingSystem
    {
        private readonly int _value;

        public CapacitanceNumberingSystem(int value)
        {
            _value = value;
        }

        public static implicit operator CapacitanceNumberingSystem(MicroFarads mf)
        {
            var pf = (MicroFarads)mf;

            if(mf.Value > 0 && mf.Value < 100)
            {
                //return new CapacitanceNumberingSystem(mf.Value);
            }

            //var base10Log = Math.Log10(pf.Value);
            var test = 1000;
            
            var part = LTR(test).Reverse().Take(2).Reverse();

            //list.TrueForAll(x => x.Equals(filterValue))

            // value in pF + number of 0's the value would have in pf. 
            throw new NotImplementedException("");
        }

        private static IEnumerable<long> LTR(long x)
        {
            // if (x < 10) return ??;
            long bound = x/10;
            long lastPowerOfTen = 1;

            while(lastPowerOfTen <= bound)
            {
                lastPowerOfTen *= 10; // doesn't overflow
            }

            long powerOfTen = 1;
            do
            {
                powerOfTen *= 10;
                yield return x % powerOfTen;
            } while(powerOfTen < lastPowerOfTen);
        }
    }

}
