namespace MaterialsDomain
{
    public struct NanoFarads
    {
        public NanoFarads(double value)
        {
            Value = value;
        }

        public double Value { get; }

        public static implicit operator double(NanoFarads nf)
        {
            return nf.Value;
        }

        public static implicit operator NanoFarads(double value)
        {
            return new NanoFarads(value);
        }

        public static implicit operator MicroFarads(NanoFarads nf)
        {
            return new MicroFarads((nf * 0.001));
        } 

        public static implicit operator PicoFarads(NanoFarads nf)
        {
            return new PicoFarads((long)(nf * 1000).Value);
        }

        public static NanoFarads operator *(NanoFarads nf, double x)
        {
            return new NanoFarads(nf.Value * x);
        }
    }

}
