namespace Dashboard.Shared.Exceptions
{
    public class EmptyUserNameException
        : DashboardException
    {
        public EmptyUserNameException(string typeOfName)
            : base($"User {typeOfName} cannot be empty.")
        {
        }
    }
}
