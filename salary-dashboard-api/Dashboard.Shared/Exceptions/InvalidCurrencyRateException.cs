namespace Dashboard.Shared.Exceptions
{
    public class InvalidCurrencyRateException
        : DashboardException
    {
        private double Value { get; }

        public InvalidCurrencyRateException(double value)
            : base($"Currency rate: {value} cannot be less or equals zero.")
        {
            Value = value;
        }
    }
}
