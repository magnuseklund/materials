using System;
using System.Globalization;

namespace MaterialsDomain
{
    public enum ComponentType
    {
        None = 0,
        ThroughHole,
        Smt
    }

    public interface IComponentType
    {
    }

    public interface IThroughHoleComponentType : IComponentType
    {}

    public interface ISmtComponentType : IComponentType
    {}

    public interface IComponentTypeProperties<TComponentType>
        where TComponentType : IComponentType
    {

    }

    internal class ThroughHoleComponentProperties : IComponentTypeProperties<IThroughHoleComponentType>
    {}

    internal class SmtComponentProperties : IComponentTypeProperties<ISmtComponentType>
    {
        public int NumberOfTerminals { get; }
    }

    public static class SmtPackageCodes
    {
        public static SmtPackageCode Package_0201 = new SmtPackageCode(0.25, 0.125);
        public static SmtPackageCode Package_03015 = new SmtPackageCode(0.3, 0.15);
        public static SmtPackageCode Package_0402 = new SmtPackageCode(0.4, 0.2);
    }

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

    public struct SmtPackageCode
    {
        // todo: convert between metric and imperial.
        private readonly double _length;

        private readonly double _width;

        private readonly MeasurementSystem _measurementSystem;

        public SmtPackageCode(double length, double width, MeasurementSystem measurementSystem = MeasurementSystem.Metric)
        {
            Check.InRange(length, 0.25, 7.4, nameof(length));
            Check.InRange(width, 0.125, 5.1, nameof(width));

            _length = length;
            _width = width;
            _measurementSystem = measurementSystem;
        }

        public override string ToString()
        {
            if(_measurementSystem == MeasurementSystem.Metric)
            {
                var l = FormatMeasurement(_length);
                var w = FormatMeasurement(_width);

                return $"{l}{w}";
            }

            return $"";
        }

        private string FormatMeasurement(double value)
        {
            return value.ToString("0.00", CultureInfo.InvariantCulture)
                    .Replace(".", "")
                    .Substring(0, 2);
        }

        public SmtPackageCode ToImperial()
        {
            return new SmtPackageCode(_length * 0.039370, _width * 0.039370, MeasurementSystem.Imperial);
        }

        public SmtPackageCode ToMetric()
        {
            return new SmtPackageCode(_length * 25.4, _width * 25.4);
        }
    }

    public enum MeasurementSystem
    {
        None = 0,
        Metric,
        Imperial
    }

    public interface IComponent<TComponentType>
        where TComponentType : IComponentType
    {
        IComponentTypeProperties<TComponentType> Properties { get; }
    }

    internal class ThroughHoleComponent : IComponent<IThroughHoleComponentType>
    {
        private readonly IComponentTypeProperties<IThroughHoleComponentType> _properties = new ThroughHoleComponentProperties();

        public ThroughHoleComponent()
        {
        }

        public IComponentTypeProperties<IThroughHoleComponentType> Properties => _properties;
    }

    public class ThroughHoleComponentFactory
    {
        public static IComponent<IThroughHoleComponentType> Resistor(object value, object leadSpacing)
        {
            return new ThroughHoleComponent();
        }
    }
}