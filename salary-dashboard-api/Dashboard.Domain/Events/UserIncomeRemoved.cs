using Dashboard.Abstraction.Domain;
using Dashboard.Domain.Entities;

namespace Dashboard.Domain.Events
{
    public record UserIncomeRemoved(IncomeList List, Income Income) : IDomainEvent;
}
