using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Repositories;
using Dashboard.Domain.ValueObjects;
using Dashboard.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.EF.Repositories
{
    internal sealed class PostgresIncomeListRepository
        : IIncomeListRepository
    {
        private readonly DbSet<IncomeList> _incomeLists;
        private readonly WriteDbContext _writeDbContext;

        public PostgresIncomeListRepository(WriteDbContext writeDbContext)
        {
            _incomeLists = writeDbContext.IncomeLists;
            _writeDbContext = writeDbContext;
        }

        public async Task<IEnumerable<IncomeList>> GetUserIncomeListsAsync(UserId userId)
        {
            return await _incomeLists.Include("_incomes")
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public Task<IncomeList> GetAsync(UserId userId, IncomeListId id)
        {
            var incomeList = _incomeLists
                .Include(x => x.User)
                .Include("_incomes")
                .SingleOrDefaultAsync(x => x.User.Id == userId && x.Id == id);

            return incomeList;
        }

        public async Task<IncomeList> AddAsync(IncomeList list)
        {
            var result = await _incomeLists.AddAsync(list);
            await _writeDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IncomeList> UpdateAsync(IncomeList list)
        {
            var result = _incomeLists.Update(list);
            await _writeDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync(IncomeList list)
        {
            _incomeLists.Remove(list);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
