namespace Dashboard.Shared.Exceptions
{
    public class IncomeListNotFoundException
        : DashboardException
    {
        public IncomeListNotFoundException() : base($"Income list was not found.")
        {
        }
    }
}
