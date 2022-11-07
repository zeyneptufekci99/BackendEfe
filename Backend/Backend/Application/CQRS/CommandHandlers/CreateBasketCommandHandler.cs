using MediatR;
using Backend.Application.CQRS.Commands;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.CommandHandlers
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand>
    {
        private readonly Context _context;

        public CreateBasketCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var createdBasket=new Basket();
            createdBasket.UserId=request.UserId;

            await _context.Baskets.AddAsync(createdBasket);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
