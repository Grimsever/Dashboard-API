using System;
using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record IncomeListId
    {
        public Guid Value { get; }

        public IncomeListId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyIncomeIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(IncomeListId vale)
            => vale.Value;

        public static implicit operator IncomeListId(Guid value)
            => new IncomeListId(value);
    }
}
