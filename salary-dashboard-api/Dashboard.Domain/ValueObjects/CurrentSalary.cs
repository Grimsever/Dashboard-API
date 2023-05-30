using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record CurrentSalary
    {
        public decimal Value { get; }

        public CurrentSalary(decimal value)
        {
            if (value <= 0)
            {
                throw new InvalidSalaryException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(CurrentSalary vale)
            => vale.Value;

        public static implicit operator CurrentSalary(decimal value)
            => new CurrentSalary(value);
    }
}
