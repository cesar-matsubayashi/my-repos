using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRepos.Application.GithubSearches.SearchAllProjects;
using MyRepos.Contracts.GithubSearch;

namespace MyRepos.Api.Controllers
{
    [Route("repositorio")]
    public class GithubSearchController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public GithubSearchController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositoriesByName(
            [FromQuery] string q,
            [FromQuery] int page)
        {
            var query = _mapper.Map<SearchRepositoriesByNameQuery>((q, page));
            var searchRepositories = await _mediator.Send(query);

            return searchRepositories.Match(
                repositories => Ok(_mapper.Map<GithubSearchResponse>(repositories)),
                errors => Problem(errors));
        }
    }
}
