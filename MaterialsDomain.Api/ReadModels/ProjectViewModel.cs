using System;
using GraphQL;
using GraphQL.Types;
using MaterialsDomain.Api.Data;

namespace MaterialsDomain.Api.ReadModels
{
    public class ProjectQuery : ObjectGraphType<ProjectViewModel>
    {
        private readonly IProjectRepository _projectRepository;
        
        public ProjectQuery()
        {
            Name = "Project Query";

            // this.FieldAsync<ProjectViewModel>(
            //     "project",
            //     arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>>
            //     {
            //         Name = "id",
            //         Description = "Id of the project"
            //     }),
            //     resolve: context => await _projectRepository.GetProjects().First());
        }
    }

    public class ProjectViewModel : ObjectGraphType
    {
        public Guid Id { get; set; }
        
        public string Name { get; set;}
    }
}