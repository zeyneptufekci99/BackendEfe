using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetSizeByIdQueryHandler : IRequestHandler<GetSizeByIdQuery,SizeDto?>
    {
        private readonly Context _context;

        public GetSizeByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<SizeDto?> Handle(GetSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var Size = await _context.Sizes.AsNoTracking().OfType<Size>().Select(x => new SizeDto
            {
                Id = x.Id,
                Name = x.Name,

            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return Size;
        }
    }
}
