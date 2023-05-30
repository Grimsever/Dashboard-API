using System;
using System.Threading.Tasks;
using Dashboard.Abstraction.Queries;
using Dashboard.Application.Commands;
using Dashboard.Application.DTO;
using Dashboard.Application.Queries;
using Dashboard.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Api.Controllers
{
    [Route("api/income-lists")]
    [ApiController]
    public class IncomeListController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public IncomeListController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("id:guid")]
        public async Task<ActionResult<IncomeListDto>> Get([FromRoute] GetIncomeList query)
        {
            var res = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateIncomeList command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return CreatedAtAction(nameof(Get), new { id = command.UserId }, null);
        }
    }
}
