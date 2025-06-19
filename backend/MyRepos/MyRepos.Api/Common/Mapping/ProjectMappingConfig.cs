using Mapster;
using MyRepos.Application.Projects.Commands.CreateProject;
using MyRepos.Application.Projects.Queries.GetProjectById;
using MyRepos.Contracts.Project;
using MyRepos.Domain.Project;
using MyRepos.Domain.Project.ValueObjects;

namespace MyRepos.Api.Common.Mapping
{
    public class ProjectMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProjectRequest, CreateProjectCommand>();

            config.NewConfig<Project, ProjectResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<Guid, GetProjectByIdQuery>()
                .Map(dest => dest.Id, src => ProjectId.Create(src));
        }
    }
}
