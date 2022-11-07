
using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetProductTypeByIdQuery : IRequest<ProductTypeDto?>
    {
        public int Id { get; set; }

        public GetProductTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
