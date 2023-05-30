using System;

namespace SecurityAPI.Domain.Enums
{
    [Flags]
    public enum Role
    {
        Admin = 1,
        User = 2,
    }
}