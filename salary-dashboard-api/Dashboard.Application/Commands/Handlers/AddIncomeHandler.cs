using System;
using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Repositories;
using Dashboard.Shared.Commands;
using Dashboard.Shared.Exceptions;

namespace Dashboard.Application.Commands.Handlers
{
    public class AddIncomeHandler
        : ICommandHandler<AddIncome, IncomeList>
    {
        private readonly IIncomeListRepository _repository;

        public AddIncomeHandler(IIncomeListRepository repository)
        {
            _repository = repository;
        }

        public async Task<IncomeList> HandleAsync(AddIncome command)
        {
            var (userId, incomeListId, incomeAmount, percentSalary, incomedAt,
                currencyRate, incomeType, currencyType) = command;

            var incomeList = await _repository.GetAsync(userId, incomeListId);

            if (incomeList is null)
            {
                throw new IncomeListNotFoundException();
            }

            var income = new Income()
            {
                Id = new Guid(),
                CurrencyRate = currencyRate,
                CurrencyType = currencyType,
                IncomeAmount = incomeAmount,
                PercentSalary = percentSalary,
                IncomedAt = incomedAt,
                IncomeType = incomeType
            };

            incomeList.AddIncome(income);

            return await _repository.UpdateAsync(incomeList);
        }
    }
}
