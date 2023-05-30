using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Domain.Constants;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Policies;
using Dashboard.Domain.ValueObjects;

namespace Dashboard.Domain.Factories
{
    public sealed class IncomeListFactory : IIncomeListFactory
    {
        private readonly IEnumerable<IIncomePolicy> _policies;

        public IncomeListFactory(IEnumerable<IIncomePolicy> policies)
        {
            _policies = policies;
        }

        public IncomeList Create(UserId userId, CurrentSalary currentSalary)
            => new(userId, new Guid(), currentSalary);

        public IncomeList CreateWithItems(UserId userId, bool isUsual, Currency currency,
            IncomeCurrencyRate currencyRate,
            MonthNumber monthNumber,
            CurrentSalary salary)
        {
            var data = new PolicyData(userId, isUsual, currency, currencyRate, monthNumber, salary);

            var applicablePolicies = _policies.Where(x => x.IsApplicable(data));

            var items = applicablePolicies.SelectMany(p => p.GenerateIncomes(data));

            var incomeList = Create(userId, salary);

            incomeList.AddIncomes(items);

            return incomeList;
        }
    }
}
