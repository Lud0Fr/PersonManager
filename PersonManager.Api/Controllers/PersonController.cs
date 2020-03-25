using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonManager.Api.Commands;
using PersonManager.Api.Queries;
using System.Threading.Tasks;

namespace PersonManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ApiControllerBase
    {
        private readonly IPersonQueries _queries;
        
        public PersonController(
            IMediator mediator,
            IPersonQueries queries)
            : base(mediator)
        {
            _queries = queries;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddPersonCommand command)
        {
            return Ok(await HandleAsync(command));
        }

        [HttpGet]
        public async Task<IActionResult> Add([FromQuery]string keyword)
        {
            return Ok(await _queries.Search(keyword));
        }
    }
}
