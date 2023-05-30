using System;
using Dashboard.Abstraction.Queries;
using Dashboard.Application.DTO;

namespace Dashboard.Application.Queries
{
    public class GetUser
        : IQuery<UserDto>
    {
        public Guid Id { get; set; }
    }
}
