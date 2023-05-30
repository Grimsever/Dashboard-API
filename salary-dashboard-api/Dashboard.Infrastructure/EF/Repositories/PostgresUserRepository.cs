using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Repositories;
using Dashboard.Domain.ValueObjects;
using Dashboard.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.EF.Repositories
{
    internal sealed class PostgresUserRepository : IUserRepository
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly DbSet<User> _users;

        public PostgresUserRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _users = writeDbContext.Users;
        }

        public async Task<User> GetAsync(UserId id)
        {
            return await _users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> AddAsync(User user)
        {
            var result = await _users.AddAsync(user);

            await _writeDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var result = _users.Update(user);

            await _writeDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);

            await _writeDbContext.SaveChangesAsync();
        }
    }
}
