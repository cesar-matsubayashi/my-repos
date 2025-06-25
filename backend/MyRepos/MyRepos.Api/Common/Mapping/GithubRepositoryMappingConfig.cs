using Mapster;
using MyRepos.Contracts.GithubRepository;
using MyRepos.Domain.GithubRepositoryAggregate;

namespace MyRepos.Api.Common.Mapping
{
    public class GithubRepositoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GithubRepository, GithubRepositoryResponse>()
                .Map(dest => dest.GithubId, src => src.Id.Value);
        }
    }
}
