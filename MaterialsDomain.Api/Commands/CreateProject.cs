using System;

namespace MaterialsDomain.Api.Commands
{
    // Inventory
    // Projects
    //  - Manufacturer
    //  - BoM
    //  - Build Steps
    //  - Schematics
    // Bill of Materials

    public class CreateProject : BaseCommand
    {
        public string Name { get; set; }

        public CreateProject(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
    }
}