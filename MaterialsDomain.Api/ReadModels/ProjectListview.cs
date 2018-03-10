using System;
using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Events;
using Newtonsoft.Json;
using StackExchange.Redis;
using MaterialsDomain.Api.Data;
using MaterialsDomain.Api.Events;

namespace MaterialsDomain.Api.ReadModels
{
    public class ProjectListview : ICancellableEventHandler<ProjectCreated>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectListview(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task Handle(ProjectCreated message, CancellationToken token = default(CancellationToken))
        {
            await _projectRepository.CreateAsync(message.Name);
        }
    }
}