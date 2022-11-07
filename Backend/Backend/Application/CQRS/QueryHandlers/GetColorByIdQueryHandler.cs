using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetColorByIdQueryHandler : IRequestHandler<GetColorByIdQuery,ColorDto?>
    {
        private readonly Context _context;

        public GetColorByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<ColorDto?> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
        {
            var Color = await _context.Colors.AsNoTracking().OfType<Color>().Select(x => new ColorDto
            {
                Id = x.Id,
                Name = x.Name,

            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return Color;
        }
    }
}
