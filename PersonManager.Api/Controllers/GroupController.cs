using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonManager.Api.Queries;
using System.Threading.Tasks;

namespace PersonManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ApiControllerBase
    {
        private readonly IGroupQueries _queries;

        public GroupController(
            IMediator mediator,
            IGroupQueries queries)
            : base(mediator)
        {
            _queries = queries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _queries.GetAllAsync());
        }
    }
}
