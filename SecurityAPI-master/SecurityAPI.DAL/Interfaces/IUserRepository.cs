using System.Collections.Generic;
using System.Threading.Tasks;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        
        Task<User> GetByIdAsync(int id);
        
        Task<User> GetByUserNameAsync(string userName);
        
        Task<User> UpdateAsync(User user);
        
        Task<User> CreateAsync(User user);
        
        Task<int> DeleteAsync(int id);
    }
}