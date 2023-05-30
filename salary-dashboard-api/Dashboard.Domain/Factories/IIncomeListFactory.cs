using Dashboard.Domain.Constants;
using Dashboard.Domain.Entities;
using Dashboard.Domain.ValueObjects;

namespace Dashboard.Domain.Factories
{
    public interface IIncomeListFactory
    {
        IncomeList Create(UserId userId, CurrentSalary currentSalary);

        IncomeList CreateWithItems(UserId userId, bool isUsual, Currency currency, IncomeCurrencyRate currencyRate,
            MonthNumber monthNumber,
            CurrentSalary salary);
    }
}
