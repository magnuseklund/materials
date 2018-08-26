using System;

namespace MaterialsDomain
{
    public interface IComponentTypeProperties<TComponentType>
        where TComponentType : IComponentType
    {

    }

    public struct Resistor : IDesignatable
    {
        public decimal ResistanceValue { get; }

        public Resistor(decimal resistanceValue)
        {
            ResistanceValue = resistanceValue;
        }

        public string Shorthand
        {
            get
            {
                if(ResistanceValue < 1000)
                {
                    return $"{ResistanceValue}R";
                }

                return "";
            }
        }

        public override string ToString()
        {
            return string.Format(new ResistanceFormatter(), "S", this);
        }
    }

    public struct Designation
    {
        public IDesignatable Component { get; }

        public string Placement { get; }

        public Designation(IDesignatable component, string placement)
        {
            Component = component;
            Placement = placement;
        }
    }

    public static class DesignatableExtensions
    {
        public static Designation Designate(this IDesignatable designatable, string placement)
        {
            return new Designation(designatable, placement);
        }

        public static Designation Designate<T>(this T designatable, int placement)
            where T : IDesignatable
        {
            if(typeof(T) == typeof(Resistor))
            {
                return new Designation(designatable, $"R{placement}");
            }

            throw new NotImplementedException();
        }
    }

    public interface IDesignatable
    {}

    public class ResistanceFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Format: S - ShortHand
            // Format: default - resistance value in ohm
            Check.IsOfType<Resistor>(arg, nameof(arg));

            var r = (Resistor)arg;

            if(r.ResistanceValue < 1000)
            {
                return $"{r.ResistanceValue}R";
            }

            if(r.ResistanceValue >= 1000 && r.ResistanceValue < 1000000)
            {
                // 1k 
                return $"{r.ResistanceValue / 1000}K";
            }

            return $"{r.ResistanceValue / 1000000}M";
        }

        public object GetFormat(Type formatType)
        {
            if(formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }
    }

    public struct Capacitor
    {

    }
}