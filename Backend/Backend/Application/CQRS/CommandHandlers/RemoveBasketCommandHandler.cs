using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Commands;
using Backend.Data.Context;

namespace Backend.Application.CQRS.CommandHandlers
{
    public class RemoveBasketCommandHandler : IRequestHandler<RemoveBasketCommand>
    {
        private readonly Context _context;

        public RemoveBasketCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveBasketCommand request, CancellationToken cancellationToken)
        {
            var removedBasket = await _context.Baskets.SingleOrDefaultAsync(x => x.Id == request.Id);
            if(removedBasket != null)
            {
                _context.Baskets.Remove(removedBasket);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}
