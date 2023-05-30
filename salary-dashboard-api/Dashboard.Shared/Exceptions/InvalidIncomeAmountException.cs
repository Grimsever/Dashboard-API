namespace Dashboard.Shared.Exceptions
{
    public class InvalidIncomeAmountException
        : DashboardException
    {
        private decimal Value { get; }

        public InvalidIncomeAmountException(decimal value)
            : base($"Income amount: {value} is invalid.")
        {
            Value = value;
        }
    }
}
