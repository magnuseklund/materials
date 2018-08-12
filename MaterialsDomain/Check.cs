using System;

namespace MaterialsDomain
{
    public static class Check
    {
        public static void IsOfType<T>(object obj, string param)
        {
            if(obj.GetType() == typeof(T))
            {
                return;
            }

            throw new ArgumentException(param);
        }

        public static void IsNotNull<T>(T obj, string param)
            where T : class
        {
            if(obj != null)
            {
                return;
            }

            throw new ArgumentNullException(param);
        }

        public static void IsNotNegative(int value, string param)
        {
            if(value >= 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(param);
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