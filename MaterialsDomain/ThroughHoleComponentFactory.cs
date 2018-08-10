namespace MaterialsDomain
{
    public class ThroughHoleComponentFactory
    {
        public static IComponent<IThroughHoleComponentType> Resistor(object value, object leadSpacing)
        {
            return new ThroughHoleComponent();
        }
    }
}