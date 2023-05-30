namespace Dashboard.Domain.ValueObjects
{
    public record UserMiddleName : UserName
    {
        public UserMiddleName(string value) : base(value, "Middle Name")
        {
        }

        public static implicit operator string(UserMiddleName vale)
            => vale.Value;

        public static implicit operator UserMiddleName(string value)
            => new UserMiddleName(value);
    }
}
