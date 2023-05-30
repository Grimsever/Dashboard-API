using System;
using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record IncomeId
    {
        public Guid Value { get; }

        public IncomeId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyIncomeIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(IncomeId vale)
            => vale.Value;

        public static implicit operator IncomeId(Guid value)
            => new IncomeId(value);
    }
}
