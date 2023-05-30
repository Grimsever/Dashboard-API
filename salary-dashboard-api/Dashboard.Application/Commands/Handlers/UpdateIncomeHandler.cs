using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Repositories;
using Dashboard.Domain.ValueObjects;
using Dashboard.Shared.Commands;
using Dashboard.Shared.Exceptions;

namespace Dashboard.Application.Commands.Handlers
{
    public class UpdateIncomeHandler
        : ICommandHandler<UpdateIncome, IncomeList>
    {
        private readonly IIncomeListRepository _repository;

        public UpdateIncomeHandler(IIncomeListRepository repository)
        {
            _repository = repository;
        }

        public async Task<IncomeList> HandleAsync(UpdateIncome command)
        {
            var (userId, incomeListId, incomeId, incomeAmount, percentSalary, incomedAt,
                currencyRate, incomeType, currencyType) = command;

            var incomeList = await _repository.GetAsync(userId, incomeId);

            if (incomeList is null)
            {
                throw new IncomeListNotFoundException();
            }

            var newIncome = new Income
            {
                CurrencyRate = currencyRate,
                CurrencyType = currencyType,
                IncomeAmount = incomeAmount,
                PercentSalary = percentSalary,
                IncomedAt = incomedAt,
                IncomeType = incomeType
            };

            incomeList.UpdateIncome(incomeId, newIncome);

            return await _repository.UpdateAsync(incomeList);
        }
    }
}
