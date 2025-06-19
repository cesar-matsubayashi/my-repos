using Mapster;
using MyRepos.Application.Projects.Commands.CreateProject;
using MyRepos.Contracts.Project;
using MyRepos.Domain.Project;

namespace MyRepos.Api.Common.Mapping
{
    public class DinnerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProjectRequest, CreateProjectCommand>();

            config.NewConfig<Project, ProjectResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
