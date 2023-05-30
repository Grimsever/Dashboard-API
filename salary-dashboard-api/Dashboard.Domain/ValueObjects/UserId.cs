using System;
using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record UserId
    {
        public Guid Value { get; }

        public UserId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyUserIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(UserId vale)
            => vale.Value;

        public static implicit operator UserId(Guid value)
            => new UserId(value);
    }
}
