namespace Dashboard.Shared.Exceptions
{
    public class InvalidMonthNumberException
        : DashboardException
    {
        public int Value { get; }

        public InvalidMonthNumberException(int value)
            : base($"Month number: {value} is invalid.")
        {
            Value = value;
        }
    }
}
