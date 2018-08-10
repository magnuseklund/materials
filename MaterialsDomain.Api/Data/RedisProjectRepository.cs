using Newtonsoft.Json;
using StackExchange.Redis;
using MaterialsDomain.Api.Models;
using System.Threading.Tasks;
using MaterialsDomain.Api.ReadModels;
using System.Linq;
using System.Collections.Generic;

namespace MaterialsDomain.Api.Data
{
    internal class RedisProjectRepository : IProjectRepository
    {
        private readonly IDatabase _database;

        public RedisProjectRepository(ConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<ProjectListViewModel> GetProjectListAsync()
        {
            var data = await _database.StringGetAsync(nameof(ProjectListview));

            return JsonConvert.DeserializeObject<ProjectListViewModel>(data);
        }

        public async Task CreateAsync(ProjectViewModel project)
        {
            var data = await _database.StringGetAsync(nameof(ProjectListview));
            
            if(data.HasValue)
            {
                var list = JsonConvert.DeserializeObject<ProjectListViewModel>(data);

                if(!list.Projects.Any(x => x.Name == project.Name))
                {
                    list.Projects.Add(project);

                    await _database.StringSetAsync(nameof(ProjectListview), JsonConvert.SerializeObject(list));
                }

                return;
            }

            var model = new ProjectListViewModel();
            model.Projects.Add(project);

            await _database.StringSetAsync(nameof(ProjectListview), JsonConvert.SerializeObject(model));
        }

        public Task<IEnumerable<ProjectViewModel>> GetProjects()
        {
            throw new System.NotImplementedException();
        }
    }
}