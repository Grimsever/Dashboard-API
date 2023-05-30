using System;
using System.Collections.Generic;

namespace Dashboard.Application.DTO
{
    public class IncomeListDto
    {
        public Guid Id { get; set; }

        public decimal CurrentSalary { get; set; }

        public UserDto User { get; set; }

        public IEnumerable<IncomeDto> Incomes { get; set; }
    }
}
