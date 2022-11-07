
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetSizeListQueryHandler : IRequestHandler<GetSizeListQuery, List<SizeDto>>
    {
        private readonly Context _context;

        public GetSizeListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<SizeDto>> Handle(GetSizeListQuery request, CancellationToken cancellationToken)
        {
            var SizeList = await _context.Sizes.OfType<Size>().Select(x => new SizeDto
            {
                Id = x.Id,
                Name = x.Name,
            }).AsNoTracking().ToListAsync();

            return SizeList;
        }
    }
}
