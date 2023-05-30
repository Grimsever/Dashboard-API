using System;

namespace Dashboard.Shared.Exceptions
{
    public class DashboardException
        : Exception
    {
        public DashboardException(string message)
            : base(message)
        {
        }
    }
}
