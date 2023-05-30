using System.Collections.Generic;
using System.Linq;
using Dashboard.Application.DTO;
using Dashboard.Infrastructure.EF.Models;

namespace Dashboard.Infrastructure.EF.Queries.Extensions
{
    internal static class IncomeExtension
    {
        public static IncomeDto AsDto(this IncomeReadModel readModel)
        {
            return new()
            {
                Id = readModel.Id,
                IncomeAmount = readModel.IncomeAmount,
                PercentSalary = readModel.PercentSalary,
                IncomedAt = readModel.IncomedAt,
                CurrencyRate = readModel.CurrencyRate,
                IncomeType = readModel.IncomeType,
                CurrencyType = readModel.CurrencyType
            };
        }

        public static IEnumerable<IncomeDto> AsDto(this IEnumerable<IncomeReadModel> readModel)
        {
            return readModel.Select(x => x.AsDto());
        }
    }
}
