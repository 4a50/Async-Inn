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
      return room;
    }
  }
}
