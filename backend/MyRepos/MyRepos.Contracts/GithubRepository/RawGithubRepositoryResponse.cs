namespace MyRepos.Contracts.GithubRepository
{
    public record RawGithubRepositoryResponse(
        int Id,
        string Name,
        string Description,
        string Language,
        DateTimeOffset Updated_At,
        OwnerMetadata Owner,
        string Html_Url);

    public record OwnerMetadata(
        string Login);
}
