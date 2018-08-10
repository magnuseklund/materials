using System;

namespace MaterialsDomain.Api.Commands
{
    public class ChangeOrderOfBuildStep : BaseCommand
    {
        public ChangeOrderOfBuildStep(Guid id)
            : base(id)
        {
            
        }
    }
}