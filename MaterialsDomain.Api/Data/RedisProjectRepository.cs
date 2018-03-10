using Newtonsoft.Json;
using StackExchange.Redis;
using MaterialsDomain.Api.Models;
using System.Threading.Tasks;
using MaterialsDomain.Api.ReadModels;

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

        public async Task CreateAsync(string projectName)
        {
            var data = await _database.StringGetAsync(nameof(ProjectListview));
            
            if(data.HasValue)
            {
                var list = JsonConvert.DeserializeObject<ProjectListViewModel>(data);

                if(!list.Projects.Contains(projectName))
                {
                    list.Projects.Add(projectName);

                    await _database.StringSetAsync(nameof(ProjectListview), JsonConvert.SerializeObject(list));
                }

                return;
            }

            var model = new ProjectListViewModel();
            model.Projects.Add(projectName);

            await _database.StringSetAsync(nameof(ProjectListview), JsonConvert.SerializeObject(model));
        }
    }
}