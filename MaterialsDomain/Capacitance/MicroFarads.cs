namespace MaterialsDomain
{
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

}
