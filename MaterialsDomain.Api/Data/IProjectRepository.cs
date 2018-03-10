using System.Threading.Tasks;
using MaterialsDomain.Api.Models;
using MaterialsDomain.Api.ReadModels;

namespace MaterialsDomain.Api.Data
{
    public interface IProjectRepository
    {
        Task CreateAsync(string projectName);

        Task<ProjectListViewModel> GetProjectListAsync();
    }
}