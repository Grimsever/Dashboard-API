using System;
using System.Collections.Generic;

namespace Dashboard.Infrastructure.EF.Models
{
    internal class UserReadModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public IEnumerable<IncomeListReadModel> IncomeList { get; set; }
    }
}
