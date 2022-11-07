
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetColorListQueryHandler : IRequestHandler<GetColorListQuery, List<ColorDto>>
    {
        private readonly Context _context;

        public GetColorListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<ColorDto>> Handle(GetColorListQuery request, CancellationToken cancellationToken)
        {
            var ColorList = await _context.Colors.OfType<Color>().Select(x => new ColorDto
            {
                Id = x.Id,
                Name = x.Name,

            }).AsNoTracking().ToListAsync();

            return ColorList;
        }
    }
}
