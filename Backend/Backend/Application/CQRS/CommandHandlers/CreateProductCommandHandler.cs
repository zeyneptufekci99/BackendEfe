using MediatR;
using Backend.Application.CQRS.Commands;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createdProduct = new Product();
            createdProduct.Name = request.Name;
            createdProduct.ImageUrl = request.ImageUrl;
            createdProduct.Summary = request.Summary;
            createdProduct.Price = request.Price;
            createdProduct.Stok = request.Stok;
            createdProduct.GenderId = request.GenderId;
            createdProduct.ProductTypeId = request.ProductTypeId;
      
            await _context.Products.AddAsync(createdProduct);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
