using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Queries.ListProject
{
    public record ListProjectsQuery() : IRequest<ErrorOr<List<Project>>>;
}
