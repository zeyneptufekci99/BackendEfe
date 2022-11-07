using MediatR;

namespace Backend.Application.CQRS.Commands
{
    public class RemoveBasketCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveBasketCommand(int id)
        {
            Id = id;
        }
    }
}
