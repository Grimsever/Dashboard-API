using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.ValueObjects;

namespace Dashboard.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(UserId id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
