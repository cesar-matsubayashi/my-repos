using Mapster;
using MyRepos.Application.Projects.Commands.ChangeFavorite;
using MyRepos.Application.Projects.Commands.CreateProject;
using MyRepos.Application.Projects.Commands.DeleteProject;
using MyRepos.Application.Projects.Commands.UpdateProject;
using MyRepos.Application.Projects.Queries.GetProjectById;
using MyRepos.Application.Projects.Queries.SearchAllProjects;
using MyRepos.Contracts.Project;
using MyRepos.Contracts.Project.Favorite;
using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

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

            config.NewConfig<(UpdateProjectRequest Request, Guid Id), UpdateProjectCommand>()
                .Map(dest => dest.Id, src => ProjectId.Create(src.Id))
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Guid, DeleteProjectCommand>()
                .Map(dest => dest.Id, src => ProjectId.Create(src));

            config.NewConfig<(ChangeFavoriteRequest Request, Guid Id), ChangeFavoriteCommand>()
                .Map(dest => dest.Id, src => ProjectId.Create(src.Id))
                .Map(dest => dest.IsFavorite, src => src.Request.IsFavorite);

            config.NewConfig<(string Query, int Page), SearchAllProjectsQuery>()
               .Map(dest => dest.Keyword, src => src.Query)
               .Map(dest => dest.Page, src => src.Page);
        }
    }
}
