using System;
using System.Threading.Tasks;
using Dashboard.Domain.Repositories;
using Dashboard.Shared.Commands;
using Dashboard.Shared.Exceptions;

namespace Dashboard.Application.Commands.Handlers
{
    public class DeleteIncomeHandler
        : ICommandHandler<DeleteIncome, Guid>
    {
        private readonly IIncomeListRepository _repository;

        public DeleteIncomeHandler(IIncomeListRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> HandleAsync(DeleteIncome command)
        {
            var (userId, incomeListId, incomeId) = command;

            var incomeList = await _repository.GetAsync(userId, incomeId);

            if (incomeList is null)
            {
                throw new IncomeListNotFoundException();
            }

            incomeList.RemoveIncome(incomeId);

            await _repository.UpdateAsync(incomeList);

            return incomeId;
        }
    }
}
