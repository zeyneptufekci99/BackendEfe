using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetBasketByIdQuery : IRequest<BasketDto?>
    {
        public int Id { get; set; }

        public GetBasketByIdQuery(int id)
        {
            Id = id;
        }
    }
}
