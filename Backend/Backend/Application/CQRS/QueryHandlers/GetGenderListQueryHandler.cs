
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetGenderListQueryHandler : IRequestHandler<GetGenderListQuery, List<GenderDto>>
    {
        private readonly Context _context;

        public GetGenderListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GenderDto>> Handle(GetGenderListQuery request, CancellationToken cancellationToken)
        {
            var GenderList = await _context.Genders.OfType<Gender>().Select(x => new GenderDto
            {
                Id = x.Id,
                Name = x.Name,
            }).AsNoTracking().ToListAsync();

            return GenderList;
        }
    }
}
