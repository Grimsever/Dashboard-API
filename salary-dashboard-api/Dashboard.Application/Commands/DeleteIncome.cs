using System;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands
{
    public record DeleteIncome(Guid UserId, Guid IncomeListId, Guid IncomeId) : ICommand<Guid>;
}
