using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SecurityAPI.BLL.Contracts.Requests;
using SecurityAPI.BLL.Contracts.Responses;
using SecurityAPI.BLL.Extensions;
using SecurityAPI.BLL.Interfaces;
using SecurityAPI.DAL.Interfaces;
using SecurityAPI.Domain.Entities;
using SecurityAPI.Domain.Exceptions;

namespace SecurityAPI.BLL.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = _mapper.Map<List<UserDto>>(await _userRepository.GetAllAsync());
            return users;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(id));
        }

        public async Task<UserDto> UpdateAsync(UpdateUserRequest user)
        {
            var updatedUser = _mapper.Map<User>(user);
            updatedUser.PasswordHash = SecurePasswordHasher.Hash(user.Password);
            updatedUser.Roles = await _roleRepository.GetAllRolesByNames(user.Roles.Select(_ => _.ToLower()).ToList());
            
            return _mapper.Map<UserDto>(await _userRepository.UpdateAsync(updatedUser));
        }

        public async Task<UserDto> CreateAsync(CreateUserRequest user)
        {
            if ((await _userRepository.GetByUserNameAsync(user.UserName)) is not null)
            {
                throw new UserExistsException($"User with username: {user.UserName} already exists");
            }
            
            var createdUser = _mapper.Map<User>(user);
            createdUser.PasswordHash = SecurePasswordHasher.Hash(user.Password);
            createdUser.Roles = await _roleRepository.GetAllRolesByNames(user.Roles.Select(_ => _.ToLower()).ToList());
            
            return _mapper.Map<UserDto>(await _userRepository.CreateAsync(createdUser));
        }

        public Task<int> DeleteAsync(int id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public Task<User> GetByUserNameAsync(string userName)
        {
            return _userRepository.GetByUserNameAsync(userName);
        }
    }
}