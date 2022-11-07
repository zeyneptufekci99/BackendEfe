using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Application.CQRS.Commands;
using Backend.Application.CQRS.Queries;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBaskets()
        {
            var result = await _mediator.Send(new GetBasketListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetBasketByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBasket(int id)
        {
            await _mediator.Send(new RemoveBasketCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
    }
}
