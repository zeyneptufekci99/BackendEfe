using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetBasketListQueryHandler : IRequestHandler<GetBasketListQuery, List<BasketDto>>
    {
        private readonly Context _context;

        public GetBasketListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<BasketDto>> Handle(GetBasketListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Baskets.AsNoTracking().Select(x => new BasketDto
            {
                Id = x.Id,
                UserId = x.UserId,

            }).ToListAsync();

            return result;
        }
    }
}
