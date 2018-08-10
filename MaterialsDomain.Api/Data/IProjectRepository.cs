using System.Collections.Generic;
using System.Threading.Tasks;
using MaterialsDomain.Api.Models;
using MaterialsDomain.Api.ReadModels;

namespace MaterialsDomain.Api.Data
{
    public interface IProjectRepository
    {
        Task CreateAsync(ProjectViewModel project);

        Task<ProjectListViewModel> GetProjectListAsync();

        Task<IEnumerable<ProjectViewModel>> GetProjects();
    }
}