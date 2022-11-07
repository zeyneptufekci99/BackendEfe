using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Commands;
using Backend.Data.Context;

namespace Backend.Application.CQRS.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Name = request.Name;
                updatedProduct.ImageUrl = request.ImageUrl;
                updatedProduct.Summary = request.Summary;
                updatedProduct.Price = request.Price;
                updatedProduct.Stok = request.Stok;
                updatedProduct.GenderId = request.GenderId;
                updatedProduct.ProductTypeId = request.ProductTypeId;
      


                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
