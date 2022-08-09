using BaggageTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace BaggageTracking.Data
{
    public class BaggageDbContext : DbContext
    {
        public BaggageDbContext(DbContextOptions<BaggageDbContext> dbContext) : base(dbContext) { }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>().HasMany(a => a.Platforms)
                .WithOne(p => p.Airport).HasForeignKey(p => p.AirportId);

            modelBuilder.Entity<Airport>().HasMany(a => a.ToAirports)
                .WithOne(t => t.ToAirport).HasForeignKey(t => t.ToAirportId);

            modelBuilder.Entity<Airport>().HasMany(a => a.FromAirports)
                .WithOne(t => t.FromAirport).HasForeignKey(t => t.FromAirportId);



            modelBuilder.Entity<Status>().HasMany(a => a.Loadings)
               .WithOne(t => t.Loading).HasForeignKey(t => t.LoadingId);

            modelBuilder.Entity<Status>().HasMany(a => a.Landeds)
               .WithOne(t => t.Landed).HasForeignKey(t => t.LandedId);

            modelBuilder.Entity<Status>().HasMany(a => a.IsOuts)
               .WithOne(t => t.IsOut).HasForeignKey(t => t.IsOutId);

            modelBuilder.Entity<Ticket>().HasOne(t => t.Baggage)
                .WithOne(b => b.Ticket).HasForeignKey<Baggage>(x=>x.Id);

            AppDbInitializer.ApplyDbSeedData(modelBuilder);
        }

    }
}
