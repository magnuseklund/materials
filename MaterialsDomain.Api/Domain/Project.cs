using System;
using CQRSlite.Domain;
using MaterialsDomain.Api.Events;

namespace MaterialsDomain.Api.Domain
{
    public class Project : AggregateRoot
    {
        public string Name { get; private set; }

        public Project(Guid id, string name)
        {
            Id = id;
            ApplyChange(new ProjectCreated(id, name));   
        }

        private void Apply(ProjectCreated e)
        {
            Name = e.Name;
        }
    }
}