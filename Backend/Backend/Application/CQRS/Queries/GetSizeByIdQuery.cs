
using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetSizeByIdQuery : IRequest<SizeDto?>
    {
        public int Id { get; set; }

        public GetSizeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
