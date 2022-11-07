using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.CQRS.Commands;
using Backend.Application.CQRS.Queries;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductTypes()
        {
            var result = await _mediator.Send(new GetProductTypeListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetProductTypeByIdQuery(id));
            return Ok(result);
        }


    }
}
