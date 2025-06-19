using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Queries.SearchAllProjects
{
    public record SearchAllProjectsQuery (
        string Keyword,
        int Page) : IRequest<ErrorOr<List<Project>>>;
}
