using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.CQRS.Commands;
using Backend.Application.CQRS.Queries;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ColorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            var result = await _mediator.Send(new GetColorListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetColorByIdQuery(id));
            return Ok(result);
        }

        
    }
}
