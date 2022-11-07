using MediatR;

namespace Backend.Application.CQRS.Commands
{
    public class UpdateBasketCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
