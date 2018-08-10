using System;

namespace MaterialsDomain.Api.Commands
{
    public class AddBuildStepToProject : BaseCommand
    {
        public AddBuildStepToProject(Guid id)
            : base(id)
        {
            
        }
    }
}