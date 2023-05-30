using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Abstraction.Queries;
using Dashboard.Application.DTO;
using Dashboard.Application.Queries;
using Dashboard.Infrastructure.EF.Contexts;
using Dashboard.Infrastructure.EF.Models;
using Dashboard.Infrastructure.EF.Queries.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.EF.Queries.Handler
{
    internal sealed class SearchIncomeListsHandler
        : IQueryHandler<SearchIncomeLists, IEnumerable<IncomeListDto>>
    {
        private readonly DbSet<IncomeListReadModel> _incomeList;

        public SearchIncomeListsHandler(ReadDbContext readDbContext)
        {
            _incomeList = readDbContext.IncomeLists;
        }

        public async Task<IEnumerable<IncomeListDto>> HandleAsync(SearchIncomeLists query)
        {
            var dbQuery = _incomeList
                .Include(x => x.User)
                .Include(x => x.Incomes)
                .AsQueryable();

            if (query is not null)
            {
                dbQuery = dbQuery.Where(x => x.User.Id == query.UserId && x.CurrentSalary == query.Salary);
            }

            return await dbQuery
                .Select(x => x.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
