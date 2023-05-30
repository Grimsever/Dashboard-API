namespace Dashboard.Shared.Exceptions
{
    public class IncomeNotFoundException : DashboardException
    {
        public IncomeNotFoundException() : base($"Income was not found.")
        {
        }
    }
}
