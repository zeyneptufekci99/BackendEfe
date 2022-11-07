using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,UserDto?>
    {
        private readonly Context _context;

        public GetUserByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var User = await _context.Users.AsNoTracking().OfType<User>().Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                Surname = x.Surname,
                Username = x.Username,
                Email = x.Email,
                BasketId = x.BasketId,
                RoleId = x.RoleId,
             
            }).SingleOrDefaultAsync(p => p.Id == request.Id);


            return User;
        }
    }
}
