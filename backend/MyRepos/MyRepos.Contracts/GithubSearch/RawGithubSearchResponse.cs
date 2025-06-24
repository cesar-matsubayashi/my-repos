namespace MyRepos.Contracts.GithubSearch
{
    public record RawGithubSearchResponse(
        int Total_Count,
        List<RawGithubSearchRepositoryResponse> Items);

    public record RawGithubSearchRepositoryResponse(
        int Id,
        string Name,
        string Description,
        string Language,
        DateTimeOffset Updated_At,
        GithubSearchOwnerMetadata Owner,
        string Html_Url);

    public record GithubSearchOwnerMetadata(
        string Login);
}
