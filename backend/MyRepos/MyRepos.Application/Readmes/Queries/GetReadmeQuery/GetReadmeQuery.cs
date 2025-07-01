using ErrorOr;
using MediatR;
using MyRepos.Domain.ReadmeAggreate;

namespace MyRepos.Application.Readmes.Queries.GetReadmeQuery
{
    public record GetReadmeQuery(
        string Owner,
        string RepositoryName) : IRequest<ErrorOr<Readme>>;
}