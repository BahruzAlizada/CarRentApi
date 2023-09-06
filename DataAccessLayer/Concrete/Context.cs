using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;


namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=RentCarApi; Integrated Security=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<CarYear> CarYears { get; set; }
        public DbSet<CarCountryMarket> CarCountryMarkets { get; set; }
        public DbSet<CarEngineType> CarEngineTypes { get; set; }
        public DbSet<CarNumberSeat> CarNumberSeats { get; set; }
        public DbSet<CarGearBox> CarGearBoxes { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
            .HasOne(c => c.SubCategory)
            .WithMany(sc => sc.Cars)
            .HasForeignKey(c => c.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
