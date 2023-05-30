namespace Dashboard.Shared.Exceptions
{
    public class EmptyUserIdException
        : DashboardException
    {
        public EmptyUserIdException()
            : base("User ID cannot be empty.")
        {
        }
    }
}
