namespace Dashboard.Shared.Exceptions
{
    public class InvalidSalaryException
        : DashboardException
    {
        private decimal Value { get; }

        public InvalidSalaryException(decimal value)
            : base($"User salary: {value} is invalid.")
        {
            Value = value;
        }
    }
}
