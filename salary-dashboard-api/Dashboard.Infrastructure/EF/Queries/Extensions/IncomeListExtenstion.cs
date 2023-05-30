using Dashboard.Application.DTO;
using Dashboard.Infrastructure.EF.Models;

namespace Dashboard.Infrastructure.EF.Queries.Extensions
{
    internal static class IncomeListExtenstion
    {
        public static IncomeListDto AsDto(this IncomeListReadModel readModel)
        {
            return new()
            {
                Id = readModel.Id, CurrentSalary = readModel.CurrentSalary, Incomes = readModel.Incomes.AsDto()
            };
        }
    }
}
