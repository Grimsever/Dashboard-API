using System;
using System.Collections.Generic;

namespace Dashboard.Infrastructure.EF.Models
{
    internal class IncomeListReadModel
    {
        public Guid Id { get; set; }

        public decimal CurrentSalary { get; set; }

        public UserReadModel User { get; set; }

        public IEnumerable<IncomeReadModel> Incomes { get; set; }
    }
}
