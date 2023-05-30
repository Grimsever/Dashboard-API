using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.DAL.Persistence
{
    internal sealed class SecurityAPIContext : DbContext
    {
        public SecurityAPIContext(DbContextOptions<SecurityAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        
        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}