using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRepos.Application.GithubRepositories.Queries.ListMyGithubRepositories;
using MyRepos.Contracts.GithubRepository;

namespace MyRepos.Api.Controllers
{
    [Route("repositorio")]
    public class GithubController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        //TODO: create dotnet user-secrets
        private readonly string GITHUB_USER = "cesar-matsubayashi";

        public GithubController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("meus")]
        public async Task<IActionResult> ListMyGithubRepositories()
        {
            var query = new ListMyGithubRepositoriesQuery(GITHUB_USER);
            var listMyGithubRepositoriesQuery = await _mediator.Send(query);

            return listMyGithubRepositoriesQuery.Match(
                repositories => Ok(_mapper.Map<List<GithubRepositoryResponse>>(repositories)),
                errors => Problem(errors));
        }
    }
}
