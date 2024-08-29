using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Features.ProductsFeatures.Commands;
using OnlineShop.Application.Features.ProductsFeatures.Queries;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Products")]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [Route("allproducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQuery());
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("addproducts")]
        public async Task<ActionResult> AddProducts([FromBody] AddProductCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}