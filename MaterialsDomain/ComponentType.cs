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