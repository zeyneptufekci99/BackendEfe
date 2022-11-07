
using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetColorByIdQuery : IRequest<ColorDto?>
    {
        public int Id { get; set; }

        public GetColorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
