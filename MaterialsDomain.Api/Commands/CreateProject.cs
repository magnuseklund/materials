using System;

namespace MaterialsDomain.Api.Commands
{
    public class CreateProject : BaseCommand
    {
        public string Name { get; set; }

        public CreateProject(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}