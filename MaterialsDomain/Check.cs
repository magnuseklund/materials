using System;

namespace MaterialsDomain
{
    public static class Check
    {
        public static void IsNotNull(object obj, string param)
        {
            if(obj != null)
            {
                return;
            }

            throw new ArgumentNullException(param);
        }

        public static void IsNotNullOrWhitespace(string value, string param)
        {
            if(!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            throw new ArgumentNullException(param);
        }

        public static void InRange(double value, double from, double to, string param)
        {
            if(value >= from && value <= to)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(param);
        }
    }
}