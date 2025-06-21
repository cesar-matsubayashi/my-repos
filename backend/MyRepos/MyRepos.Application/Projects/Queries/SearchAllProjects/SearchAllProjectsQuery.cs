using ErrorOr;
using MediatR;
using MyRepos.Domain.Search;

namespace MyRepos.Application.Projects.Queries.SearchAllProjects
{
    public record SearchAllProjectsQuery (
        string Keyword,
        int Page) : IRequest<ErrorOr<SearchResult>>;
}
