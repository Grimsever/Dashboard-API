using System;
using Dashboard.Abstraction.Queries;
using Dashboard.Application.DTO;

namespace Dashboard.Application.Queries
{
    public class GetIncomeList
        : IQuery<IncomeListDto>
    {
        public Guid Id { get; set; }
    }
}
