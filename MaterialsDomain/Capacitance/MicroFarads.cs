using System;

namespace MaterialsDomain
{
    public struct MicroFarads
    {
        private readonly FaradsSpecification _faradsSpecification;

        public MicroFarads(double value)
        {
            Value = value;
            _faradsSpecification = new FaradsSpecification('µ', 10^-6);
        }

        public double Value { get; }

        public static implicit operator double(MicroFarads mf)
        {
            return mf.Value;
        }

        public static implicit operator MicroFarads(double value)
        {
            return new MicroFarads(value);
        }

        public static implicit operator NanoFarads(MicroFarads mf)
        {
            return new NanoFarads((mf * 1000).Value);
        } 

        public static implicit operator PicoFarads(MicroFarads mf)
        {
            return new PicoFarads((long)(mf * 1000000).Value);
        }

        public static MicroFarads operator *(MicroFarads mf, int x)
        {
            return new MicroFarads(mf.Value * x);
        }

        public override string ToString()
        {
            return $"{Value} {_faradsSpecification.SiSymbol}F";
        }
    }
}
