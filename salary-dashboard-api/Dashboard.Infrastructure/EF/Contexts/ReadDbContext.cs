using Dashboard.Infrastructure.EF.Configs;
using Dashboard.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext
        : DbContext
    {
        public DbSet<IncomeReadModel> Incomes { get; set; }

        public DbSet<UserReadModel> Users { get; set; }

        public DbSet<IncomeListReadModel> IncomeLists { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("income");

            var configuration = new ReadConfiguration();

            modelBuilder.ApplyConfiguration<IncomeListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<IncomeReadModel>(configuration);
            modelBuilder.ApplyConfiguration<UserReadModel>(configuration);
        }
    }
}
