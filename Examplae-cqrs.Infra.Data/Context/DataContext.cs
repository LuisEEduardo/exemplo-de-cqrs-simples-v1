using Examplae_cqrs.Infra.Data.Mappings;
using Example_cqrs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examplae_cqrs.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
