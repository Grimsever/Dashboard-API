using System.Collections.Generic;
using SecurityAPI.Domain.Common;

namespace SecurityAPI.Domain.Entities
{
    public class IdentityRole : BaseEntity<int>
    {
        public string Name { get; set; }
        
        public List<User> Users { get; set; }
    }
}