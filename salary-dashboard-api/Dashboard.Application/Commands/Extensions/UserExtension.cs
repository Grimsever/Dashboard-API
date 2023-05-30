using Dashboard.Application.DTO;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Commands.Extensions
{
    public static class UserExtension
    {
        public static UserDto AsDto(this User user)
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
