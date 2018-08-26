using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialsDomain
{
    public struct CapacitanceNumberingSystem
    {
        public CapacitanceNumberingSystem(int value)
        {
            // Example: 473 = 47pF * 1000 (3 zeroes) = 47 000pf, 47nF, 0,047uF
            CapacitanceCode = value;
        }

        public int CapacitanceCode { get; }
        

        public static implicit operator CapacitanceNumberingSystem(MicroFarads mf)
        {
            var pf = (PicoFarads)mf;

            return FromPf(pf);
        }

        public static implicit operator CapacitanceNumberingSystem(PicoFarads pf)
        {
            return FromPf(pf);
        }

        public static implicit operator CapacitanceNumberingSystem(NanoFarads nf)
        {
            var pf = (PicoFarads)nf;

            return FromPf(pf);
        }

        private static CapacitanceNumberingSystem FromPf(PicoFarads pf)
        {
            // 47000pF 
            var parts = pf.Value.GetLongArray();

            // 47
            var capValue = parts.Take(2).Select(x => Convert.ToInt32(x)).ToArray().ConcatNumbers();

            // 3
            var zeroes = parts.Skip(2).Count();

            return new CapacitanceNumberingSystem(new[] { capValue, zeroes}.ConcatNumbers());
        }

        public static implicit operator PicoFarads(CapacitanceNumberingSystem c)
        {
            // 47000pF 
            // 4,7,3
            var parts = c.CapacitanceCode.GetIntArray();

            // 47
            var capValue = parts.Take(2).ToArray().ConcatNumbers();

            // 3
            var zeroes = parts.Skip(2).Count();

            for(int i = 0; i < 3; i++)
            {
                capValue = capValue * 10;
            }

            return new PicoFarads(capValue);
        }

        public static implicit operator MicroFarads(CapacitanceNumberingSystem c)
        {
            var pf = (PicoFarads)c;

            return (MicroFarads)pf;
        }

        public static implicit operator NanoFarads(CapacitanceNumberingSystem c)
        {
            var pf = (PicoFarads)c;

            return (NanoFarads)pf;
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
