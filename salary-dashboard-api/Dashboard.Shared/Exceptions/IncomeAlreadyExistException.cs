using System;

namespace Dashboard.Shared.Exceptions
{
    public class IncomeAlreadyExistException
        : DashboardException
    {
        public IncomeAlreadyExistException(DateTime date, decimal amount)
            : base($"Income with value: {amount} at the date: {date:dd/MM/yyyy} already exist.")
        {
        }
    }
}
