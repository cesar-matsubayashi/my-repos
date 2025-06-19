using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Queries.ListMyProjects
{
    public record ListMyProjectsQuery(string User) : IRequest<ErrorOr<List<Project>>>;
}
