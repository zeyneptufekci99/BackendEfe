
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Commands;
using Backend.Data.Context;

namespace Backend.Application.CQRS.CommandHandlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly Context _context;

        public RemoveUserCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveUserCommand command)
        {
            var removedUser = _context.Users.SingleOrDefault(x => x.Id == command.Id);
            if (removedUser != null)
            {
                _context.Users.Remove(removedUser);
                _context.SaveChanges();
            }

        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var removedUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (removedUser != null)
            {
                _context.Users.Remove(removedUser);
                _context.SaveChanges();
            }

            return Unit.Value;
        }
    }
}
