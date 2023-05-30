using System;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands
{
    public record UpdateUser(Guid UserId, string FirstName, string LastName, string MiddleName)
        : ICommand;
}
