using System.Globalization;

namespace MaterialsDomain
{
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
}