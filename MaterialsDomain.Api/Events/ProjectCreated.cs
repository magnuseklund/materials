using System;

namespace MaterialsDomain.Api.Events
{
    public class ProjectCreated : BaseEvent
    {
        public string Name {get;}

        public ProjectCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}