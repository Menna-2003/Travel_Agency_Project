﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel_Agency_Project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Travel_Agency_Project.Data {
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) {
        
        }
        // Add new table to the database
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<UserReservationDetails> UserReservationDetails { get; set; }
        public DbSet<UserFavourites> UserFavourites { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }

        // predefined data in the table
        protected override void OnModelCreating ( ModelBuilder modelBuilder ) {

            // to add multiple rows in the same run
            base.OnModelCreating( modelBuilder );
            modelBuilder.Entity<UserReservationDetails>().HasKey( ur => ur.ID );

            // lma 3malt Identity gab error fel add-migration flazem ytshal
            //    modelBuilder.Entity<Transportation>().HasData(
            //        new Transportation { ID = 1, Name = "Car" },
            //        new Transportation { ID = 2, Name = "Plane" },
            //        new Transportation { ID = 3, Name = "Bike" },
            //        new Transportation { ID = 4, Name = "Bus" }
            //        );
        }
    }
}
