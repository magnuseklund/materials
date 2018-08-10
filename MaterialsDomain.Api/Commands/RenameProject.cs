using System;

namespace MaterialsDomain.Api.Commands
{
    public class RenameProject : BaseCommand
    {
        public string NewName { get; set; }

        public RenameProject(Guid id, string newName)
            : base(id)
        {
            NewName = newName;
        }
    }
}