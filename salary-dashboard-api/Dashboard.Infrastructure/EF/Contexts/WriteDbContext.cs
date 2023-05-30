using Dashboard.Domain.Entities;
using Dashboard.Infrastructure.EF.Configs;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext
        : DbContext
    {
        public DbSet<IncomeList> IncomeLists { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<User> Users { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("income");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<User>(configuration);
            modelBuilder.ApplyConfiguration<IncomeList>(configuration);
            modelBuilder.ApplyConfiguration<Income>(configuration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
