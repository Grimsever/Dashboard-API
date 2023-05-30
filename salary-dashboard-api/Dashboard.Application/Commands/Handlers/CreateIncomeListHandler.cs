using System.Threading.Tasks;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Factories;
using Dashboard.Domain.Repositories;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands.Handlers
{
    public class CreateIncomeListHandler
        : ICommandHandler<CreateIncomeList, IncomeList>
    {
        private readonly IIncomeListRepository _repository;
        private readonly IIncomeListFactory _factory;


        public CreateIncomeListHandler(IIncomeListRepository repository,
            IIncomeListFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<IncomeList> HandleAsync(CreateIncomeList command)
        {
            var (userId, salary) = command;

            var incomeList = _factory.Create(userId, salary);

            return await _repository.AddAsync(incomeList);
        }
    }
}
