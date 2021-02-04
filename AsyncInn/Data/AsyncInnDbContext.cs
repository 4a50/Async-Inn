﻿using AsyncInn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AsyncInn.Data
{
  public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Hotel> Hotel { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<RoomAmenity> RoomAmenities { get; set; }
    public DbSet<HotelRoom> HotelRoom { get; set; }

    public AsyncInnDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 1, Name = "Spook Central", StreetAddress = "1234 Gozer Blvd", City = "New York", State = "New York", Country = "USA", Phone = "(555) 123-4566", HotelRoom= new List<HotelRoom>() });
      modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 2, Name = "Tower Of Terror", StreetAddress = "1 Twilight Zone Dr.", City = "Orlando", State = "Florida", Country = "USA", Phone = "(224) 478-2231" });
      modelBuilder.Entity<Hotel>().HasData(new Hotel { Id = 3, Name = "Starfleet Officer Quarter", StreetAddress = "1 Cochran Way", City = "San Francisco", State = "California", Country = "UFP", Phone = "(333) 333-3333" });

      modelBuilder.Entity<Room>().HasData(new Room { ID = 1, Name = "Ivo Shandor Suite", Layout = 0 });
      modelBuilder.Entity<Room>().HasData(new Room { ID = 2, Name = "Admiral Picard Ready Room", Layout = 1 });
      modelBuilder.Entity<Room>().HasData(new Room { ID = 3, Name = "Fox McCloud Suite", Layout = 2 });

      modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 1, Name = "Replicator" });
      modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 2, Name = "Mini-Bar" });
      modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 3, Name = "Coffee Pot" });

      modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom { HotelID = 1, RoomNumber = 1001, RoomID = 1, Rate = 120.22M, PetFriendly = true });

      modelBuilder.Entity<RoomAmenity>().HasKey(
        roomamenities => new { roomamenities.AmenityId, roomamenities.RoomId }
        );
      modelBuilder.Entity<HotelRoom>().HasKey(
        hotelroom => new { hotelroom.RoomNumber, hotelroom.HotelID}
        );

      //Build Model.
      //Add a DbSet.
      //Create a composite key
      //modelBuilder.Entity<****>().HasKey(
      //**** => new (****.CourseId, ****.StudentID
    }


  }
}
