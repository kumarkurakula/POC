﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}