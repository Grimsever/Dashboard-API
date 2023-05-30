namespace Dashboard.Shared.Exceptions
{
    public class InvalidIncomePercentsOfSalaryException
        : DashboardException
    {
        public int Value { get; }

        public InvalidIncomePercentsOfSalaryException(int value)
            : base($"Set percent: {value} is invalid.")
        {
            Value = value;
        }
    }
}
