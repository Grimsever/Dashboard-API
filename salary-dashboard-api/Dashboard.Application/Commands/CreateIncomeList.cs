using System;
using Dashboard.Domain.Entities;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands
{
    public record CreateIncomeList(Guid UserId, decimal Salary) : ICommand<IncomeList>;
}
