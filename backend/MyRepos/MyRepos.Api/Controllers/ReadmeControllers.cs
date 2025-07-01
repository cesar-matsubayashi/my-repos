using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRepos.Application.Readmes.Queries.GetReadmeQuery;
using MyRepos.Contracts.Readme;

namespace MyRepos.Api.Controllers
{
    [Route("repositorio")]
    public class ReadmeControllers : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ReadmeControllers(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{owner}/{name}/readme")]
        public async Task<IActionResult> GetReadme(
            string owner,
            string name)
        {
            var query = _mapper.Map<GetReadmeQuery>((owner, name));
            var getReadmeQuery = await _mediator.Send(query);

            return getReadmeQuery.Match(
                readme => Ok(_mapper.Map<ReadmeResponse>(readme)),
                errors => Problem(errors));
        }
    }
}
