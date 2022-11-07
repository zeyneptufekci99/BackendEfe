using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly Context _context;

        public GetProductByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
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



            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}
