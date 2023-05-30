using System;
using Dashboard.Domain.Constants;

namespace Dashboard.Application.DTO
{
    public class IncomeDto
    {
        public Guid Id { get; set; }

        public decimal IncomeAmount { get; set; }

        public int PercentSalary { get; set; }

        public DateTime IncomedAt { get; set; }

        public double CurrencyRate { get; set; }

        public IncomeType IncomeType { get; set; }

        public Currency CurrencyType { get; set; }
    }
}
