using System.Collections.Generic;
using Dashboard.Domain.ValueObjects;

namespace Dashboard.Domain.Entities
{
    public class User
    {
        public UserId Id { get; set; }

        public UserName FirstName { get; set; }

        public UserLastName LastName { get; set; }

        public UserMiddleName MiddleName { get; set; }

        public IEnumerable<IncomeList> IncomeLists { get; set; } = new List<IncomeList>();
    }
}
