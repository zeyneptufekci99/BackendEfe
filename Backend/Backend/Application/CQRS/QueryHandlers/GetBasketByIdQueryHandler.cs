using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQuery, BasketDto?>
    {
        private readonly Context _context;

        public GetBasketByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<BasketDto?> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Baskets.AsNoTracking().Select(x => new BasketDto
            {
                Id = x.Id,
                UserId = x.UserId,


            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}
