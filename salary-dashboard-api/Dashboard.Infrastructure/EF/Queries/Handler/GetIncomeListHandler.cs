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
    internal sealed class GetIncomeListHandler
        : IQueryHandler<GetIncomeList, IncomeListDto>
    {
        private readonly DbSet<IncomeListReadModel> _incomeList;

        public GetIncomeListHandler(ReadDbContext readDbContext)
        {
            _incomeList = readDbContext.IncomeLists;
        }

        public async Task<IncomeListDto> HandleAsync(GetIncomeList query)
        {
            var incomeList = await _incomeList
                .Include(x => x.Incomes)
                .Where(x => x.Id == query.Id)
                .Select(x => x.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();

            return incomeList;
        }
    }
}
