using Mapster;
using MyRepos.Application.Readmes.Queries.GetReadmeQuery;
using MyRepos.Contracts.Readme;
using MyRepos.Domain.ReadmeAggreate;

namespace MyRepos.Api.Common.Mapping
{
    public class ReadmeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(string Owner, string RepositoryName), GetReadmeQuery>()
                .Map(dest => dest.Owner, src => src.Owner)
                .Map(dest => dest.RepositoryName, src => src.RepositoryName);

            config.NewConfig<Readme, ReadmeResponse>();
        }
    }
}
