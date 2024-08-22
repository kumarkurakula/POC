using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OA.Service.Features.ProductsFeatures.Commands;
using OA.Service.Features.ProductsFeatures.Queries;
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
        [Route("listproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        [HttpPost]
        [Route("AddProducts")]
        public async Task<IActionResult> PostProducts([FromBody] AddProductCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}