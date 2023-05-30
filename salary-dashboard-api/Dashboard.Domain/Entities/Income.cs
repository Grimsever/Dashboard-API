using System;
using Dashboard.Domain.Constants;
using Dashboard.Domain.ValueObjects;

namespace Dashboard.Domain.Entities
{
    public class Income
    {
        public IncomeId Id { get; set; }

        public IncomeAmount IncomeAmount { get; set; }

        public IncomePercentsOfSalary PercentSalary { get; set; }

        public DateTime IncomedAt { get; set; }

        public IncomeCurrencyRate CurrencyRate { get; set; }

        public IncomeType IncomeType { get; set; }

        public Currency CurrencyType { get; set; }
    }
}
