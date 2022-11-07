using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly Context _context;

        public GetProductListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.AsNoTracking().Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Summary = x.Summary,
                Price = x.Price,
                Stok = x.Stok,
                GenderId = x.GenderId,
                ProductTypeId = x.ProductTypeId,    

            }).ToListAsync();

            return result;
        }
    }
}