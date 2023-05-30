using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Application.DTO;

namespace Dashboard.Application.Services
{
    public interface IIncomeListReadService
    {
        Task<IEnumerable<IncomeListDto>> SearchAsync(string searchPhrase);
    }
}
