using MyRepos.Domain.Project;

namespace MyRepos.Domain.Search
{
    public sealed class SearchResult
    {
        private readonly List<MyRepos.Domain.Project.Project> _projects = new();
        public int TotalCount { get; set; }
        public IReadOnlyList<MyRepos.Domain.Project.Project> Projects => _projects.AsReadOnly();
        private SearchResult(
            int totalCount,
            List<MyRepos.Domain.Project.Project> projects)
        {
            TotalCount = totalCount;
            _projects = projects;
        }

        public static SearchResult Create(
            int totalCount,
            List<MyRepos.Domain.Project.Project> projects)
        {
            var search = new SearchResult(totalCount, projects);
            return search;
        }

    }
}
