using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTests
{
  public abstract class Mock : IDisposable
  {
    private readonly SqliteConnection _connection;
    protected readonly AsyncInnDbContext _db;

    public Mock()
    {
      _connection = new SqliteConnection("Filename=:memory:");
      _connection.Open();

      _db = new AsyncInnDbContext(
        new DbContextOptionsBuilder<AsyncInnDbContext>()
        .UseSqlite(_connection)
        .Options);
      _db.Database.EnsureCreated();
    }

    public void Dispose()
    {
      _db?.Dispose();
      _connection?.Dispose();

    }

    protected async Task<Amenity> CreateAndSaveNewAmenity()
    {
      var amenity = new Amenity
      {
        Name = "Hot Chocolate"
      };
      _db.Amenities.Add(amenity);
      await _db.SaveChangesAsync();
      Assert.NotEqual(0, amenity.ID);
      _db.Entry(amenity).State = EntityState.Detached;
      return amenity;
    }
    protected async Task<Room> CreateAndSaveANewRoomType()
    {
      var room = new Room
      {
        Name = "Suite of 1000 Mirrors",
        Layout = 1
      };
      _db.Room.Add(room);
      await _db.SaveChangesAsync();
      Assert.NotEqual(0, room.ID);
      _db.Entry(room).State = EntityState.Detached;
      return room;
    }
    public async Task<Hotel> CreateAndSaveANewHotel()
    {
      var hotel = new Hotel
      {
        Name = "Obscura",
        StreetAddress = "Middle Of Your Mind",
        City = "Hippocampus",
        State = "Brain",
        Country = "You",
        Phone = "(123) 123 - 1233"
      };
      _db.Hotel.Add(hotel);
      await _db.SaveChangesAsync();
      Assert.NotEqual(0, hotel.Id);
      _db.Entry(hotel).State = EntityState.Detached;
      return hotel;
    }
    public async Task<HotelRoom> CreateAndSaveHotelRoom()
    {
      var hotelRoom = new HotelRoom
      {
        HotelID = 2,
        RoomID = 1,
        PetFriendly = false,
        Rate = 100.00M,
        RoomNumber = 1234
      };
      _db.HotelRoom.Add(hotelRoom);
      await _db.SaveChangesAsync();
      _db.Entry(hotelRoom).State = EntityState.Detached;
      return hotelRoom;
    }    
  }
}
