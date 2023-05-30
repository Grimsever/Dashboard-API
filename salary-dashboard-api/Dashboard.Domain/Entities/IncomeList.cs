using System.Collections.Generic;
using System.Linq;
using Dashboard.Abstraction.Domain;
using Dashboard.Domain.Events;
using Dashboard.Domain.ValueObjects;
using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.Entities
{
    public class IncomeList
        : AggregateRoot<IncomeListId>
    {
        public IncomeListId Id { get; set; }

        public CurrentSalary CurrentSalary { get; set; }

        public UserId UserId { get; set; }
        public User User { get; set; }

        private readonly LinkedList<Income> _incomes = new();

        private IncomeList()
        {
        }

        internal IncomeList(UserId userId, IncomeListId id, CurrentSalary currentSalary)
        {
            Id = id;
            UserId = userId;
            CurrentSalary = currentSalary;
        }

        internal IncomeList(UserId userId, IncomeListId id, CurrentSalary currentSalary, LinkedList<Income> incomes)
            : this(userId, id, currentSalary)
        {
            AddIncomes(incomes);
        }

        public void AddIncome(Income income)
        {
            var alreadyExist =
                _incomes.Any(x => x.IncomeAmount == income.IncomeAmount && x.IncomedAt == income.IncomedAt);

            if (alreadyExist)
            {
                throw new IncomeAlreadyExistException(income.IncomedAt, income.IncomeAmount);
            }

            _incomes.AddLast(income);

            AddEvent(new UserIncomeAdded(this, income));
        }

        public void AddIncomes(IEnumerable<Income> incomes)
        {
            foreach (var income in incomes)
            {
                AddIncome(income);
            }
        }

        public void RemoveIncome(IncomeId id)
        {
            var income = GetIncome(id);

            _incomes.Remove(income);
            AddEvent(new UserIncomeRemoved(this, income));
        }

        public void UpdateIncome(IncomeId id, Income income)
        {
            var prevIncome = _incomes.FirstOrDefault(x => x.Id == id);

            if (prevIncome is null)
            {
                throw new IncomeNotFoundException();
            }

            income.Id = prevIncome.Id;

            RemoveIncome(id);

            AddIncome(income);
        }

        private Income GetIncome(IncomeId id)
        {
            var income = _incomes.FirstOrDefault(x => x.Id == id);

            if (income is null)
            {
                throw new IncomeNotFoundException();
            }

            return income;
        }
    }
}
