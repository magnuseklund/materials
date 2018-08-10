using System;

namespace MaterialsDomain.Api.Commands
{
    public class AddBomToProject : BaseCommand
    {
        public Guid BomId { get; set; }

        public AddBomToProject(Guid id, Guid bomId)
            : base(id)
        {
            BomId = bomId;
        }
    }
}