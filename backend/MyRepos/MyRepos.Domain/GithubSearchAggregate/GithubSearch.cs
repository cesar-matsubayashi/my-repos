using MyRepos.Domain.GithubRepositoryAggregate;

namespace MyRepos.Domain.GithubSearchAggregate
{
    public sealed class GithubSearch
    {
        private readonly List<GithubRepository> _repositories = new();
        public int TotalCount { get; set; }
        public IReadOnlyList<GithubRepository> Repositories => _repositories.AsReadOnly();
        private GithubSearch(
            int totalCount,
            List<GithubRepository> repositories)
        {
            TotalCount = totalCount;
            _repositories = repositories;
        }

        public static GithubSearch Create(
            int totalCount,
            List<GithubRepository> repositories)
        {
            var search = new GithubSearch(totalCount, repositories);
            return search;
        }
    }
}
