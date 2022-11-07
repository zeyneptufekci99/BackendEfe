using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetGenderByIdQueryHandler : IRequestHandler<GetGenderByIdQuery,GenderDto?>
    {
        private readonly Context _context;

        public GetGenderByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<GenderDto?> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
        {
            var Gender = await _context.Genders.AsNoTracking().OfType<Gender>().Select(x => new GenderDto
            {
                Id = x.Id,
                Name = x.Name,

            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return Gender;
        }
    }
}
