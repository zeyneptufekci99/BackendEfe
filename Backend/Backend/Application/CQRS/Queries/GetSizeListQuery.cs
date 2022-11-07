
using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetSizeListQuery : IRequest<List<SizeDto>>
    {
    }
}
