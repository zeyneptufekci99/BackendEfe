using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetProductTypeByIdQueryHandler : IRequestHandler<GetProductTypeByIdQuery,ProductTypeDto?>
    {
        private readonly Context _context;

        public GetProductTypeByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<ProductTypeDto?> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var ProductType = await _context.ProductTypes.AsNoTracking().OfType<ProductType>().Select(x => new ProductTypeDto
            {
                Id = x.Id,
                Name = x.Name,

            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return ProductType;
        }
    }
}
