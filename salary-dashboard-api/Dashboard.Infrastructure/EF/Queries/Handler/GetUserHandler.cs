using System.Threading.Tasks;
using Dashboard.Abstraction.Queries;
using Dashboard.Application.DTO;
using Dashboard.Application.Queries;
using Dashboard.Infrastructure.EF.Contexts;
using Dashboard.Infrastructure.EF.Models;
using Dashboard.Infrastructure.EF.Queries.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.EF.Queries.Handler
{
    internal sealed class GetUserHandler
         : IQueryHandler<GetUser, UserDto>
    {
        private readonly DbSet<UserReadModel> _users;

        public GetUserHandler(ReadDbContext readDbContext)
        {
            _users = readDbContext.Users;
        }

        public async Task<UserDto> HandleAsync(GetUser query)
        {
            var user = await _users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == query.Id);

            return user.AsDto();
        }
    }
}
