using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Application.DTO;
using Dashboard.Application.Services;

namespace Dashboard.Infrastructure.EF.Services
{
    public class PostgresIncomeListReadService
        : IIncomeListReadService
    {
        public Task<IEnumerable<IncomeListDto>> SearchAsync(string searchPhrase)
        {
            throw new System.NotImplementedException();
        }
    }
}
