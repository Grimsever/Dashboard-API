using System;
using Dashboard.Domain.Constants;
using Dashboard.Domain.Entities;
using Dashboard.Domain.ValueObjects;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands
{
    public record CreateIncomeListWithItems(Guid UserId,
        bool IsUsual, Currency Currency, IncomeCurrencyRate CurrencyRate, MonthNumber MonthNumber,
        CurrentSalary Salary) : ICommand<IncomeList>;
}
