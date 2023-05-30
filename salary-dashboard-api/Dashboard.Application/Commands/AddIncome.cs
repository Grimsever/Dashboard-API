using System;
using Dashboard.Domain.Constants;
using Dashboard.Domain.Entities;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands
{
    public record AddIncome(Guid UserId, Guid IncomeListId, decimal IncomeAmount, int PercentSalary, DateTime IncomedAt,
        double CurrencyRate, IncomeType IncomeType, Currency CurrencyType) : ICommand<IncomeList>;
}
