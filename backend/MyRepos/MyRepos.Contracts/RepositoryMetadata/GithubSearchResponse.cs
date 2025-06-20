﻿namespace MyRepos.Contracts.RepositoryMetadata
{
    public record GithubSearchResponse(
        int Total_Count,
        List<GithubSearchRepositoryMetadata> Items);

    public record GithubSearchRepositoryMetadata(
        string Name,
        string Description,
        string Language,
        DateTimeOffset Updated_At,
        GithubSearchOwnerMetadata Owner,
        string Html_Url);

    public record GithubSearchOwnerMetadata(
        string Login);
}
