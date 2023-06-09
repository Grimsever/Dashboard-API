﻿using System;
using System.Collections.Generic;

namespace Dashboard.Application.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public IEnumerable<IncomeListDto> IncomeList { get; set; }
    }
}
