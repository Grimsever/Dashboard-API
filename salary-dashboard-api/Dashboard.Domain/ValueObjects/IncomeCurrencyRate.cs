using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record IncomeCurrencyRate
    {
        public double Value { get; }

        public IncomeCurrencyRate(double value)
        {
            if (value <= 0)
            {
                throw new InvalidCurrencyRateException(value);
            }

            Value = value;
        }

        public static implicit operator double(IncomeCurrencyRate vale)
            => vale.Value;

        public static implicit operator IncomeCurrencyRate(double value)
            => new IncomeCurrencyRate(value);
    }
}
