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

}
