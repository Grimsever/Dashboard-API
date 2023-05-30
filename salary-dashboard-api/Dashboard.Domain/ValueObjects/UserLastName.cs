namespace Dashboard.Domain.ValueObjects
{
    public record UserLastName : UserName
    {
        public UserLastName(string value) : base(value, "Last Name")
        {
        }

        public static implicit operator string(UserLastName vale)
            => vale.Value;

        public static implicit operator UserLastName(string value)
            => new UserLastName(value);
    }
}
