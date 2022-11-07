using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetProductByIdQuery:IRequest<ProductDto?>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}