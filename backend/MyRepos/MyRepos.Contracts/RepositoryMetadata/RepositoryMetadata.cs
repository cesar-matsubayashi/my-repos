namespace MyRepos.Contracts.RepositoryMetadata
{
    public record RepositoryMetadata(
        string Name,
        string Description,
        string Language,
        DateTimeOffset Updated_At,
        OwnerMetadata Owner,
        string Html_Url);

    public record OwnerMetadata(
        string Login);
}
