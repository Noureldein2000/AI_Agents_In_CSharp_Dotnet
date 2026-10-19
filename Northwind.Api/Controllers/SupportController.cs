using Microsoft.AspNetCore.Mvc;

using Northwind.Application.AI.Agents;

namespace Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/support")]
    public sealed class SupportController(
        ICustomerSupportAgent agent) : ControllerBase
    {
        [HttpPost("ask")]
        public async Task<IActionResult> Chat(
            string message,
            CancellationToken cancellationToken)
        {
            var response = await agent.AskAsync(
                message,
                cancellationToken);

            return Ok(response);
        }
        [HttpPost("ExecuteFlow")]
        public async Task<IActionResult> ExecuteFlow(
            string requirements,
            CancellationToken cancellationToken)
        {
            var result = await agent.ExecuteFlowAsync(requirements, cancellationToken);

            return Ok(result);
        }
    }
}
