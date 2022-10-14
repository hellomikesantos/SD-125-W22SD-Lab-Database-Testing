﻿using Microsoft.EntityFrameworkCore;

namespace SD_125_W22SD_Lab_Database_Testing.Models
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<ParkingSpot> ParkingSpots { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
