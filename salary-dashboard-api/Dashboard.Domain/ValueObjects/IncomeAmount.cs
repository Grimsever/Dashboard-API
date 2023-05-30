using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record IncomeAmount
    {
        public decimal Value { get; }

        public IncomeAmount(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidIncomeAmountException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(IncomeAmount vale)
            => vale.Value;

        public static implicit operator IncomeAmount(decimal value)
            => new IncomeAmount(value);
    }
}
