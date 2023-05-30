using System.Collections.Generic;
using System.Threading.Tasks;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.DAL.Interfaces
{
    public interface IRoleRepository
    {
        Task<IdentityRole> GetRoleByName(string name);
        
        Task<IdentityRole> AddAsync(IdentityRole role);
        
        Task<List<IdentityRole>> GetAllRolesByNames(List<string> names);
    }
}