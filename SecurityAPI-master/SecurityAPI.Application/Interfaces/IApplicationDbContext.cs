using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        
        DbSet<IdentityRole> IdentityRoles { get; set; }
        
        Task<int> SaveChangesAsync();
    }
}