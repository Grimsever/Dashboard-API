using System;
using Dashboard.Domain.Entities;
using Dashboard.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dashboard.Infrastructure.EF.Configs
{
    internal sealed class WriteConfiguration
        : IEntityTypeConfiguration<IncomeList>
            , IEntityTypeConfiguration<Income>
            , IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<IncomeList> builder)
        {
            builder.ToTable("IncomeLists");

            builder.HasKey(x => x.Id);

            var idConverter = new ValueConverter<IncomeListId, Guid>(x =>
                x.Value, x => new IncomeListId(x));

            var userIdConverter = new ValueConverter<UserId, Guid>(x =>
                x.Value, x => new UserId(x));

            var salaryConverter = new ValueConverter<CurrentSalary, decimal>(x =>
                x.Value, x => new CurrentSalary(x));

            builder.Property(x => x.Id)
                .HasConversion(idConverter);

            builder.Property(x => x.CurrentSalary)
                .HasConversion(salaryConverter)
                .HasColumnName("Salary");

            builder.Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder.Property(x => x.UserId)
                .HasConversion(userIdConverter)
                .HasColumnName("UserId");

            builder.HasMany(typeof(Income), "_incomes");
        }

        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");

            builder.HasKey(x => x.Id);

            var idConverter = new ValueConverter<IncomeId, Guid>(x =>
                x.Value, x => new IncomeId(x));

            builder.Property(x => x.Id)
                .HasConversion(idConverter);

            var amountConverter = new ValueConverter<IncomeAmount, decimal>(x =>
                x.Value, x => new IncomeAmount(x));

            var percentConverter = new ValueConverter<IncomePercentsOfSalary, int>(x =>
                x.Value, x => new IncomePercentsOfSalary(x));

            var currencyRateConverter = new ValueConverter<IncomeCurrencyRate, double>(x =>
                x.Value, x => new IncomeCurrencyRate(x));

            builder.Property(x => x.IncomeAmount)
                .HasConversion(amountConverter)
                .HasColumnName("Amount");

            builder.Property(x => x.PercentSalary)
                .HasConversion(percentConverter)
                .HasColumnName("PercentsOfSalary");

            builder.Property(x => x.CurrencyRate)
                .HasConversion(currencyRateConverter)
                .HasColumnName("CurrencyRate");
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            var idConverter = new ValueConverter<UserId, Guid>(x =>
                x.Value, x => new UserId(x));

            builder.Property(x => x.Id)
                .HasConversion(idConverter);

            var firstNameConverter = new ValueConverter<UserName, string>(x =>
                x.Value, x => new UserName(x));

            var lastNameConverter = new ValueConverter<UserLastName, string>(x =>
                x.Value, x => new UserLastName(x));

            var middleNameConverter = new ValueConverter<UserMiddleName, string>(x =>
                x.Value, x => new UserMiddleName(x));

            builder.Property(x => x.FirstName)
                .HasConversion(firstNameConverter)
                .HasColumnName("FirstName");

            builder.Property(x => x.LastName)
                .HasConversion(lastNameConverter)
                .HasColumnName("LastName");

            builder.Property(x => x.MiddleName)
                .HasConversion(middleNameConverter)
                .HasColumnName("MiddleName");

            builder.HasMany(typeof(IncomeList), "IncomeLists");
        }
    }
}
