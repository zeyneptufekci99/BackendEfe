
using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetProductTypeListQuery : IRequest<List<ProductTypeDto>>
    {
    }
}
