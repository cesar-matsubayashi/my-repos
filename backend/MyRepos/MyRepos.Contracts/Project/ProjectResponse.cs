namespace MyRepos.Contracts.Project
{
    public record ProjectResponse(
        string Id,
        string Name,
        string Description,
        string Language,
        DateTimeOffset UpdatedDateTime,
        string Owner,
        string RepositoryUrl,
        bool IsFavorite);
}
