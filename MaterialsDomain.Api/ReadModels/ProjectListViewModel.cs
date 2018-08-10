using System.Collections.Generic;

namespace MaterialsDomain.Api.ReadModels
{

    public class ProjectListViewModel
    {
        public List<ProjectViewModel> Projects { get; } = new List<ProjectViewModel>();
    }
}