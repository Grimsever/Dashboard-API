using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityAPI.DAL.Interfaces;
using SecurityAPI.DAL.Persistence;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.DAL.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly SecurityAPIContext _context;

        public UserRepository(SecurityAPIContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Include(_ => _.Roles).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(_ => _.Roles)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                .Include(_ => _.Roles)
                .FirstOrDefaultAsync(_ => _.UserName == userName);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updatedUser = _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return updatedUser.Entity;
        }

        public async Task<User> CreateAsync(User user)
        {
            var newUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return newUser.Entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var deletedUser = await _context.Users.FirstOrDefaultAsync(_ => _.Id == id);
            _context.Users.Remove(deletedUser);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}