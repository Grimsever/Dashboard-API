using System;
using System.Collections.Generic;
using Dashboard.Domain.Constants;
using Dashboard.Domain.Entities;

namespace Dashboard.Domain.Policies.UsualIncome
{
    public class CurrencyPolicy
        : IIncomePolicy
    {
        public bool IsApplicable(PolicyData data)
        {
            return data.IsUsual;
        }

        public IEnumerable<Income> GenerateIncomes(PolicyData data)
        {
            var currentYear = DateTime.Now.Year;
            var monthOfPreSalary = data.MonthNumber - 1 < 0 ? 12 : data.MonthNumber - 1;

            return new List<Income>
            {
                new Income
                {
                    Id = new Guid(),
                    CurrencyRate = data.CurrencyRate,
                    CurrencyType = data.Currency,
                    IncomeAmount = data.Salary * 0.2m,
                    IncomedAt = new DateTime(currentYear, monthOfPreSalary, 28),
                    IncomeType = IncomeType.PreSalary
                },
                new Income
                {
                    Id = new Guid(),
                    CurrencyRate = data.CurrencyRate,
                    CurrencyType = data.Currency,
                    IncomeAmount = data.Salary * 0.8m,
                    IncomedAt = new DateTime(currentYear, data.MonthNumber, 15),
                    IncomeType = IncomeType.Salary,
                }
            };
        }
    }
}
