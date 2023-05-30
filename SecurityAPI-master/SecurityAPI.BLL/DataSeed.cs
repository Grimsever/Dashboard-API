using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecurityAPI.BLL.Contracts.Requests;
using SecurityAPI.BLL.Interfaces;
using SecurityAPI.DAL.Interfaces;
using SecurityAPI.DAL.Persistence;
using SecurityAPI.Domain.Entities;
using SecurityAPI.Domain.Enums;

namespace SecurityAPI.BLL
{
    public class DataSeed
    {
        public static async Task SeedSampleDataAsync(IRoleRepository roleRepository, IUserService userService)
        {
            await CreateRolesAsync(roleRepository);
            await CreateAdminAsync(userService);
        }
        
        private static async Task CreateAdminAsync(IUserService userService)
        {
            var admin = new CreateUserRequest
            {
                Email = "admin@admin.com",
                FirstName = "Admin",
                MiddleName = "Admin",
                LastName = "Adminovich",
                UserName = "admin",
                Password = "admin",
                Roles = new List<string>{Role.Admin.ToString()}
            };

            if ((await userService.GetByUserNameAsync(admin.UserName)) is null)
            {
                await userService.CreateAsync(admin);
            }
        }

        private static async Task CreateRolesAsync(IRoleRepository roleRepository)
        {
            var enumValues = Enum.GetNames(typeof(Role));

            foreach (var role in enumValues)
            {
                if ((await roleRepository.GetRoleByName(role)) is null)
                {
                    var creationRole = new IdentityRole
                    {
                        Name = role
                    };
                    await roleRepository.AddAsync(creationRole);
                }
            }
        }
    }
}