
using MediatR;
using Backend.Application.Dtos;

namespace Backend.Application.CQRS.Queries
{
    public class GetGenderByIdQuery : IRequest<GenderDto?>
    {
        public int Id { get; set; }

        public GetGenderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
