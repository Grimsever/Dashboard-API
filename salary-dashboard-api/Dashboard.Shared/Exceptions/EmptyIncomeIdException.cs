namespace Dashboard.Shared.Exceptions
{
    public class EmptyIncomeIdException
        : DashboardException
    {
        public EmptyIncomeIdException()
            : base("Income id cannot be empty.")
        {
        }
    }
}
