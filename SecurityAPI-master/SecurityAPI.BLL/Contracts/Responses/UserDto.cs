﻿using System.Collections.Generic;

namespace SecurityAPI.BLL.Contracts.Responses
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public List<string> Roles { get; set; }
    }
}