using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SecurityAPI.BLL.Contracts.Requests.Identity;
using SecurityAPI.BLL.Contracts.Responses.Identity;
using SecurityAPI.BLL.Extensions;
using SecurityAPI.BLL.Interfaces;
using SecurityAPI.DAL.Interfaces;
using SecurityAPI.Domain.Entities;
using SecurityAPI.Domain.Enums;

namespace SecurityAPI.BLL.Implementations
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public IdentityService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<AuthenticationResult> LoginAsync(UserLoginRequest request)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);

            if (user is null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" },
                };
            }

            var userHasValidPassword = SecurePasswordHasher.Verify(request.Password, user.PasswordHash);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User/password combination is wrong" },
                };
            }

            return _tokenService.GenerateAuthenticationResultForUser(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(UserRegisterRequest request)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);

            if (user is not null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User already exist" },
                };
            }

            var newUser = _mapper.Map<User>(request);
            var userRole = await _roleRepository.GetRoleByName(nameof(Role.User));

            newUser.Roles = new List<IdentityRole> { userRole };
            newUser.PasswordHash = SecurePasswordHasher.Hash(request.Password);
            var createdUser = await _userRepository.CreateAsync(newUser);
           
            return _tokenService.GenerateAuthenticationResultForUser(createdUser);
        }
    }
}