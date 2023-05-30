using Dashboard.Shared.Exceptions;

namespace Dashboard.Domain.ValueObjects
{
    public record IncomePercentsOfSalary
    {
        public int Value { get; }

        public IncomePercentsOfSalary(int value)
        {
            if (value is 0 or > 100)
            {
                throw new InvalidIncomePercentsOfSalaryException(value);
            }

            Value = value;
        }

        public static implicit operator int(IncomePercentsOfSalary vale)
            => vale.Value;

        public static implicit operator IncomePercentsOfSalary(int value)
            => new IncomePercentsOfSalary(value);
    }
}
