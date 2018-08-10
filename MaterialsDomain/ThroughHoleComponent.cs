namespace MaterialsDomain
{
    internal class ThroughHoleComponent : IComponent<IThroughHoleComponentType>
    {
        private readonly IComponentTypeProperties<IThroughHoleComponentType> _properties = new ThroughHoleComponentProperties();

        public ThroughHoleComponent()
        {
        }

        public IComponentTypeProperties<IThroughHoleComponentType> Properties => _properties;
    }
}