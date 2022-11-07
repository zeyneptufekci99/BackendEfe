using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Commands;
using Backend.Data.Context;

namespace Backend.Application.CQRS.CommandHandlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly Context _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var removedProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedProduct != null)
            {
                _context.Products.Remove(removedProduct);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}
