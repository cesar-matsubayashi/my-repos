using Mapster;
using MyRepos.Contracts.RepositoryMetadata;
using MyRepos.Contracts.SearchResult;
using MyRepos.Domain.Search;

namespace MyRepos.Api.Common.Mapping
{
    public class SearchResulultMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SearchResult, SearchResultResponse>();
        }
    }
}
