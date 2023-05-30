using Dashboard.Domain.Constants;
using Dashboard.Domain.ValueObjects;

namespace Dashboard.Domain.Policies
{
    public record PolicyData(UserId UserId, bool IsUsual, Currency Currency, IncomeCurrencyRate CurrencyRate, MonthNumber MonthNumber,
        CurrentSalary Salary);
}
