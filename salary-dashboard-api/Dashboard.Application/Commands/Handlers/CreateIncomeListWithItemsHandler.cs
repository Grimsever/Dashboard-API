using System.Threading.Tasks;
using Dashboard.Application.Services;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Factories;
using Dashboard.Domain.Repositories;
using Dashboard.Shared.Commands;

namespace Dashboard.Application.Commands.Handlers
{
    public class CreateIncomeListWithItemsHandler
        : ICommandHandler<CreateIncomeListWithItems, IncomeList>
    {
        private readonly IIncomeListRepository _repository;
        private readonly IIncomeListFactory _factory;
        private readonly IIncomeListReadService _readService;

        public CreateIncomeListWithItemsHandler(IIncomeListReadService readService, IIncomeListFactory factory,
            IIncomeListRepository repository)
        {
            _readService = readService;
            _factory = factory;
            _repository = repository;
        }

        public async Task<IncomeList> HandleAsync(CreateIncomeListWithItems command)
        {
            var (userId, isUsual, currency, currencyRate, monthNumber, salary) = command;

            var incomeList = _factory.CreateWithItems(userId, isUsual, currency, currencyRate, monthNumber, salary);

            return await _repository.AddAsync(incomeList);
        }
    }
}
