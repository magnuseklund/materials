using System;

namespace MaterialsDomain.Api.Commands
{
    public class RemoveBuildStepFromProject : BaseCommand
    {
        public RemoveBuildStepFromProject(Guid id)
            : base(id)
        {
            
        }
    }
}