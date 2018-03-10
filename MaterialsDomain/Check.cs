using System;

namespace MaterialsDomain
{
    public static class Check
    {
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