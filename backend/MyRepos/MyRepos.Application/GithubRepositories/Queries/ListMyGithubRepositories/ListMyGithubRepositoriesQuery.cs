using ErrorOr;
using MediatR;
using MyRepos.Domain.GithubRepositoryAggregate;

namespace MyRepos.Application.GithubRepositories.Queries.ListMyGithubRepositories
{
    public record ListMyGithubRepositoriesQuery(string User) 
        : IRequest<ErrorOr<List<GithubRepository>>>;
}
