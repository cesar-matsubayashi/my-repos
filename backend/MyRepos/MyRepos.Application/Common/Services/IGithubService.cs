﻿using MyRepos.Contracts.RepositoryMetadata;

namespace MyRepos.Application.Common.Services
{
    public interface IGithubService
    {
        Task<RepositoryMetadata> GetRepositoryMetadata(string url);
        Task<List<RepositoryMetadata>> GetAllRepositoryMetadataByUser(string user);
        Task<GithubSearchResponse> GetAllRepositoryMetadataByName(string name, int page);
    }
}
