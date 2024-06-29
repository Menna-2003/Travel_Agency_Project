using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Travel_Agency_Project.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) {
        
        }
        // Add new table to the database
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Tour> Tours { get; set; }

        // predefined data in the table
        protected override void OnModelCreating ( ModelBuilder modelBuilder ) {
            modelBuilder.Entity<Transportation>().HasData(
                new Transportation { ID = 1, Name = "Car" },
                new Transportation { ID = 2, Name = "Plane" },
                new Transportation { ID = 3, Name = "Bike" },
                new Transportation { ID = 4, Name = "Bus" }
                );
        }
    }
}
