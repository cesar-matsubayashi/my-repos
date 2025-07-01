using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Services;
using MyRepos.Domain.ReadmeAggreate;

namespace MyRepos.Application.Readmes.Queries.GetReadmeQuery
{
    public class GetReadmeQueryHandler
        : IRequestHandler<GetReadmeQuery, ErrorOr<Readme>>
    {
        private readonly IGithubService _githubService;

        public GetReadmeQueryHandler(IGithubService githubService)
        {
            _githubService = githubService;
        }

        public async Task<ErrorOr<Readme>> Handle(
            GetReadmeQuery request, 
            CancellationToken cancellationToken)
        {
            var readmeMetadata = await _githubService.GetRepositoryReadme(
                request.Owner,
                request.RepositoryName);

            var readme = Readme.Create(
                readmeMetadata.Content,
                readmeMetadata.Encoding,
                readmeMetadata.Sha,
                readmeMetadata.Html_Url,
                readmeMetadata.Download_Url);

            return readme;
        }
    }
}