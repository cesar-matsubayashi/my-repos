using ErrorOr;
using MediatR;
using MyRepos.Domain.GithubSearchAggregate;

namespace MyRepos.Application.GithubSearches.SearchAllProjects
{
    public record SearchRepositoriesByNameQuery (
        string Keyword,
        int Page) : IRequest<ErrorOr<GithubSearch>>;
}
