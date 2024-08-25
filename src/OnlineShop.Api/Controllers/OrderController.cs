using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Features.OrderFeatures.Commands;
using System.Net;
using System.Threading.Tasks;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Order")]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}