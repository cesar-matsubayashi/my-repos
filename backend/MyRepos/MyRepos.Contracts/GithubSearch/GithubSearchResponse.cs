namespace MyRepos.Contracts.GithubSearch
{
    public record GithubSearchResponse(
        int TotalCount,
        List<SearchRepository> Repositories);

    public record SearchRepository(
        int GithubId,
        string Name,
        string Description,
        string Language,
        DateTimeOffset UpdatedDateTime,
        string Owner,
        string RepositoryUrl,
        bool IsFavorite);
}
