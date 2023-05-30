using System.Threading.Tasks;
using Dashboard.Abstraction.Queries;
using Dashboard.Application.Commands;
using Dashboard.Application.Commands.Extensions;
using Dashboard.Application.DTO;
using Dashboard.Application.Queries;
using Dashboard.Domain.Entities;
using Dashboard.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public UserController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> Get([FromRoute] GetUser query)
        {
            var res = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(res);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] AddUser command)
        {
            var res = await _commandDispatcher.DispatchAsync(command);

            return CreatedAtAction(nameof(Get), new { id = res.Id.Value }, res.AsDto());
        }
    }
}
