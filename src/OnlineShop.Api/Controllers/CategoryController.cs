using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Features.CategoryFeature.Commands;
using OnlineShop.Application.Features.CategoryFeature.Queries;
using OnlineShop.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Category")]
    [ApiVersion("1.0")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        [Route("allcategory")]
        public async Task<ActionResult> GetAllCategory()
        {
            var response = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(response);
        }
    }
}