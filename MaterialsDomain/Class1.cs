using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialsDomain
{
    // uF = microfarads
    // nF = nanofarads
    // pF = picofarads


    internal struct FaradsSpecification
    {
        private readonly decimal _multiplier;
        private readonly char _siSymbol;

        public FaradsSpecification(char siSymbol, decimal multiplier)
        {
            _multiplier = multiplier;
            _siSymbol = siSymbol;
        }

        public char SiSymbol { get { return _siSymbol; } }

        public decimal Multiplier { get { return _multiplier; } }
    }

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
        

    public struct MicroFarads
    {
        private readonly decimal _value;

        private readonly FaradsSpecification _faradsSpecification;

        public MicroFarads(decimal value)
        {
            _value = value;
            _faradsSpecification = new FaradsSpecification('µ', 10^-6);
        }

        public decimal Value { get { return _value; } }

        public static implicit operator decimal(MicroFarads mf)
        {
            return mf.Value;
        }

        public static implicit operator MicroFarads(decimal value)
        {
            return new MicroFarads(value);
        }

        public static implicit operator NanoFarads(MicroFarads mf)
        {
            return new NanoFarads((mf * 1000).Value);
        } 

        public static implicit operator PicoFarads(MicroFarads mf)
        {
            return new PicoFarads((mf * 1000000).Value);
        }

        public static MicroFarads operator *(MicroFarads mf, int x)
        {
            return new MicroFarads(mf.Value * x);
        }

        public override string ToString()
        {
            return $"{_value} {_faradsSpecification.SiSymbol}F";
        }
    }

    public struct NanoFarads
    {
        private readonly decimal _value;

        public NanoFarads(decimal value)
        {
            _value = value;
        }
    }

    public struct PicoFarads
    {
        private readonly decimal _value;

        public PicoFarads(decimal value)
        {
            _value = value;
        }
    }

}
