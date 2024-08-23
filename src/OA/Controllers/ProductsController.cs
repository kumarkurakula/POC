using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OA.Service.Features.ProductsFeatures.Commands;
using OA.Service.Features.ProductsFeatures.Queries;
using System.Net;
using System.Threading.Tasks;

namespace OA.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Products")]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Route("allproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQuery());
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("addproducts")]
        public async Task<IActionResult> AddProducts([FromBody] AddProductCommand request)
        {
            var response = await _mediator.Send(request);

            if (!response)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}