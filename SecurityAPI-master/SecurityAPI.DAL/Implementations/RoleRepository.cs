using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityAPI.DAL.Interfaces;
using SecurityAPI.DAL.Persistence;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.DAL.Implementations
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly SecurityAPIContext _context;

        public RoleRepository(SecurityAPIContext context)
        {
            _context = context;
        }

        public async Task<IdentityRole> GetRoleByName(string name)
        {
            return await _context.IdentityRoles.FirstOrDefaultAsync(_ => _.Name == name);
        }

        public async Task<IdentityRole> AddAsync(IdentityRole role)
        {
            var newRole = await _context.IdentityRoles.AddAsync(role);
            await _context.SaveChangesAsync();

            return newRole.Entity;
        }

        public Task<List<IdentityRole>> GetAllRolesByNames(List<string> names)
        {
            return _context.IdentityRoles.Where(_ => names.Any(name => _.Name.ToLower() == name))
                .ToListAsync();
        }
    }
}