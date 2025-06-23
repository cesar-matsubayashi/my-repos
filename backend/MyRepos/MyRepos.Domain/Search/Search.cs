namespace MyRepos.Domain.Search
{
    public sealed class SearchResult
    {
        private readonly List<ProjectAggregate.Project> _projects = new();
        public int TotalCount { get; set; }
        public IReadOnlyList<ProjectAggregate.Project> Projects => _projects.AsReadOnly();
        private SearchResult(
            int totalCount,
            List<ProjectAggregate.Project> projects)
        {
            TotalCount = totalCount;
            _projects = projects;
        }

        public static SearchResult Create(
            int totalCount,
            List<ProjectAggregate.Project> projects)
        {
            var search = new SearchResult(totalCount, projects);
            return search;
        }

    }
}
