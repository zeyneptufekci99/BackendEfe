using MediatR;

namespace Backend.Application.CQRS.Commands
{
    public class RemoveProductCommand:IRequest
    {
        public int Id { get; set; }
        public RemoveProductCommand(int id)
        {
            Id = id;
        } }}