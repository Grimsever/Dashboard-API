using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record UserName
    {
        public string Value { get; }


        public UserName(string value) : this(value, "First Name")
        {
        }

        public UserName(string value, string typeOfName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserNameException(typeOfName);
            }

            Value = value;
        }

        public static implicit operator string(UserName vale)
            => vale.Value;

        public static implicit operator UserName(string value)
            => new UserName(value);
    }
}
