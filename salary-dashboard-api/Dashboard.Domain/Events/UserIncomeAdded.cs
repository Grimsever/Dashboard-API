using Dashboard.Abstraction.Domain;
using Dashboard.Domain.Entities;

namespace Dashboard.Domain.Events
{
    public record UserIncomeAdded(IncomeList List, Income Income) : IDomainEvent;
}
