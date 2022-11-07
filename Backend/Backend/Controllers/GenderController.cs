using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.CQRS.Commands;
using Backend.Application.CQRS.Queries;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GendersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GendersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            var result = await _mediator.Send(new GetGenderListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetGenderByIdQuery(id));
            return Ok(result);
        }

    }
}
