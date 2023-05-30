using System.Collections.Generic;
using SecurityAPI.Domain.Common;

namespace SecurityAPI.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
        
        public List<IdentityRole> Roles { get; set; }
    }
}