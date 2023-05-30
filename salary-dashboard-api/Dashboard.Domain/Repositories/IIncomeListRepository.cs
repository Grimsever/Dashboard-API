using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.ValueObjects;

namespace Dashboard.Domain.Repositories
{
    public interface IIncomeListRepository
    {
        Task<IEnumerable<IncomeList>> GetUserIncomeListsAsync(UserId userId);
        Task<IncomeList> GetAsync(UserId userId, IncomeListId id);
        Task<IncomeList> AddAsync(IncomeList list);
        Task<IncomeList> UpdateAsync(IncomeList list);
        Task DeleteAsync(IncomeList list);
    }
}
