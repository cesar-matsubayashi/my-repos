namespace MyRepos.Contracts.Project
{
    public record ProjectResponse(
        string Id,
        int GithubId,
        string Name,
        string Description,
        string Language,
        DateTimeOffset UpdatedDateTime,
        string Owner,
        string RepositoryUrl,
        bool IsFavorite);
}
