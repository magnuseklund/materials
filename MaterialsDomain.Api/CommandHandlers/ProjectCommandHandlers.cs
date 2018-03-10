using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;
using MaterialsDomain.Api.Commands;
using MaterialsDomain.Api.Domain;

namespace MaterialsDomain.Api.Models
{
    public class ProjectCommandHandlers : ICommandHandler<CreateProject>
    {
        private readonly ISession _session;

        public ProjectCommandHandlers(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateProject message)
        {
            var project = new Project(message.Id, message.Name);

            await _session.Add(project);
            await _session.Commit();
        }
    }
}