
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, UserDto?>
    {
        private readonly Context _context;

        public CheckUserQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            // lazy, eagle, explicit
           var User = await _context.Users.Select(x=> new UserDto
           {
               Id = x.Id,
               Name = x.Name,
               Password= x.Password,
               Surname=x.Surname,
               Username=x.Username,
               Email = x.Email,
               BasketId = x.BasketId,
               RoleId = x.RoleId,

           }).AsNoTracking().SingleOrDefaultAsync(x=>x.Username == request.Username && x.Password == request.Password);

            return User;
        }
    }
}
