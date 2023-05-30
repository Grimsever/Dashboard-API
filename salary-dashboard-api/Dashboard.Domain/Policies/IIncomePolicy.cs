using System.Collections.Generic;
using Dashboard.Domain.Entities;

namespace Dashboard.Domain.Policies
{
    public interface IIncomePolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<Income> GenerateIncomes(PolicyData data);
    }
}
