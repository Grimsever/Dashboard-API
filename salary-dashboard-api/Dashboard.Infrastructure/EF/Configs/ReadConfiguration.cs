using Dashboard.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.EF.Configs
{
    internal sealed class ReadConfiguration
        : IEntityTypeConfiguration<IncomeListReadModel>
            , IEntityTypeConfiguration<IncomeReadModel>
            , IEntityTypeConfiguration<UserReadModel>
    {
        public void Configure(EntityTypeBuilder<IncomeListReadModel> builder)
        {
            builder.ToTable("IncomeLists");
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Incomes)
                .WithOne(x => x.IncomeList);
        }

        public void Configure(EntityTypeBuilder<IncomeReadModel> builder)
        {
            builder.ToTable("Incomes");
        }

        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.ToTable("Users");
            builder.HasMany(x => x.IncomeList)
                .WithOne(x => x.User);
        }
    }
}
