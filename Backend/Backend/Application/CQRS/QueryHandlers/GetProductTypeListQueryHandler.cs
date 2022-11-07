
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetProductTypeListQueryHandler : IRequestHandler<GetProductTypeListQuery, List<ProductTypeDto>>
    {
        private readonly Context _context;

        public GetProductTypeListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<ProductTypeDto>> Handle(GetProductTypeListQuery request, CancellationToken cancellationToken)
        {
            var ProductTypeList = await _context.ProductTypes.OfType<ProductType>().Select(x => new ProductTypeDto
            {
                Id = x.Id,
                Name = x.Name,
            }).AsNoTracking().ToListAsync();

            return ProductTypeList;
        }
    }
}
