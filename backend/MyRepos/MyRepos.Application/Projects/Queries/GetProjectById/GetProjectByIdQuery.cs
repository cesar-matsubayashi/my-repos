using ErrorOr;
using MediatR;
using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Application.Projects.Queries.GetProjectById
{
    public record GetProjectByIdQuery(
        ProjectId Id) : IRequest<ErrorOr<Project>>;
}
