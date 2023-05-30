using Dashboard.Domain.Entities;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands
{
    public record AddUser(string FirstName, string LastName, string MiddleName)
        : ICommand<User>;
}
