using System;

namespace MaterialsDomain.Api.Commands
{
    public class DeleteProject : BaseCommand
    {
        public DeleteProject(Guid id)
            : base(id)
        {
        }
    }
}