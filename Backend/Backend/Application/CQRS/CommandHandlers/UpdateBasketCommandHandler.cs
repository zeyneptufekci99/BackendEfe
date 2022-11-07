using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Commands;
using Backend.Data.Context;

namespace Backend.Application.CQRS.CommandHandlers
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand>
    {
        private readonly Context _context;

        public UpdateBasketCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var updatedBasket = await _context.Baskets.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedBasket != null)
            {
     
                updatedBasket.UserId = request.UserId;
      
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
