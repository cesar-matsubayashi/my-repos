using Mapster;
using MyRepos.Application.GithubSearches.SearchAllProjects;
using MyRepos.Contracts.GithubSearch;
using MyRepos.Domain.GithubRepositoryAggregate;
using MyRepos.Domain.GithubSearchAggregate;

namespace MyRepos.Api.Common.Mapping
{
    public class GithubSearchMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(string Query, int Page), SearchRepositoriesByNameQuery>()
                .Map(dest => dest.Keyword, src => src.Query)
                .Map(dest => dest.Page, src => src.Page);

            config.NewConfig<GithubSearch, GithubSearchResponse>();

            config.NewConfig<GithubRepository, SearchRepository>()
                .Map(dest => dest.GithubId, src => src.Id.Value);
        }
    }
}
