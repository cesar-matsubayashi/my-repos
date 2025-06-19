using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;
using MyRepos.Domain.Project.ValueObjects;

namespace MyRepos.Application.Projects.Queries.GetProjectById
{
    public record GetProjectByIdQuery(
        ProjectId Id) : IRequest<ErrorOr<Project>>;
}
