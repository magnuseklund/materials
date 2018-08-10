namespace MaterialsDomain
{
    public interface IComponent<TComponentType>
        where TComponentType : IComponentType
    {
        IComponentTypeProperties<TComponentType> Properties { get; }
    }
}