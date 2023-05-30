using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record MonthNumber
    {
        public int Value { get; }

        public MonthNumber(int value)
        {
            if (value is < 0 or > 12)
            {
                throw new InvalidMonthNumberException(value);
            }

            Value = value;
        }

        public static implicit operator int(MonthNumber vale)
            => vale.Value;

        public static implicit operator MonthNumber(int value)
            => new MonthNumber(value);
    }
}
