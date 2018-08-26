namespace MaterialsDomain
{

    public struct PicoFarads
    {
        public PicoFarads(long value)
        {
            Value = value;
        }

        public long Value { get; }

        public static implicit operator long(PicoFarads pf)
        {
            return pf.Value;
        }

        public static implicit operator PicoFarads(long value)
        {
            return new PicoFarads(value);
        }

        public static implicit operator MicroFarads(PicoFarads pf)
        {
            return new MicroFarads((pf * 0.000001));
        } 

        public static implicit operator NanoFarads(PicoFarads pf)
        {
            return new PicoFarads((long)(pf * 0.001));
        }

        public static PicoFarads operator *(PicoFarads pf, long x)
        {
            return new PicoFarads(pf.Value * x);
        }
    }
}
