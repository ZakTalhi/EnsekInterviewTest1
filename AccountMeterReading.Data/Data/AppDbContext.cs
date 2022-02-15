using AccountMeterReading.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountMeterReading.Data.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CustomerAccount> CustomerAccount { get; set; }
        public DbSet<MeterReading> MeterReading { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterReading>()
             .HasOne(p => p.CustomerAccount)
             .WithMany(b => b.MeterReading)
             .HasPrincipalKey(c=>new { c.AccountId })
             .IsRequired(false);
        }

    }
}
