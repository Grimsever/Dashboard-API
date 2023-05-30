using System;
using System.Collections.Generic;
using Dashboard.Abstraction.Queries;
using Dashboard.Application.DTO;

namespace Dashboard.Application.Queries
{
    public class SearchIncomeLists
        : IQuery<IEnumerable<IncomeListDto>>
    {
        public Guid UserId { get; set; }
        public decimal Salary { get; set; }
    }
}
