using MediatR;

namespace Backend.Application.CQRS.Commands
{
    public class CreateBasketCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
