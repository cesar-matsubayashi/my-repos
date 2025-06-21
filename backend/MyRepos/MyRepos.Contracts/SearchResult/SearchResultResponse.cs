namespace MyRepos.Contracts.SearchResult
{
    public record SearchResultResponse(
        int TotalCount,
        List<SearchRepository> Projects);

    public record SearchRepository(
        string Name,
        string Description,
        string Language,
        DateTimeOffset UpdatedDateTime,
        string Owner,
        string Html_Url);
}
