
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Application.CQRS.Queries;
using Backend.Application.Dtos;
using Backend.Data.Context;
using Backend.Data.Entities;

namespace Backend.Application.CQRS.QueryHandlers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly Context _context;

        public GetUserListQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var UserList = await _context.Users.OfType<User>().Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                Surname = x.Surname,
                Username = x.Username,
                Email = x.Email,
                BasketId = x.BasketId,
                RoleId = x.RoleId,
             
            }).AsNoTracking().ToListAsync();

            return UserList;
        }
    }
}
