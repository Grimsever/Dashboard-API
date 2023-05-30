using System.Collections.Generic;
using System.Threading.Tasks;
using SecurityAPI.BLL.Contracts.Requests;
using SecurityAPI.BLL.Contracts.Responses;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.BLL.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        
        Task<UserDto> GetByIdAsync(int id);

        Task<UserDto> UpdateAsync(UpdateUserRequest user);
        
        Task<UserDto> CreateAsync(CreateUserRequest user);
        
        Task<int> DeleteAsync(int id);
        
        Task<User> GetByUserNameAsync(string userName);
    }
}