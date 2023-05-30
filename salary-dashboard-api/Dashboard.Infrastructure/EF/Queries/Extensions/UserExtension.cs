using Dashboard.Application.DTO;
using Dashboard.Infrastructure.EF.Models;

namespace Dashboard.Infrastructure.EF.Queries.Extensions
{
    internal static class UserExtension
    {
        public static UserDto AsDto(this UserReadModel user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName
            };
        }
    }
}
