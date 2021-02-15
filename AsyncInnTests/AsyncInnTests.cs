using AsyncInn.Models.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTests
{
  public class AsyncInnTests : Mock
  {
    //TODO: Make Proper CRUD Methods to add stuff.


    [Fact]
    public async Task Can_Add_A_New_Amenity()
    {
      var amenity = await CreateAndSaveNewAmenity();
      var repository = new AmenityRepository(_db);

      var retrievedAmenity = await repository.GetAmenities();

      Assert.Contains(retrievedAmenity, e => e.Name == "Hot Chocolate");
    }
    [Fact]
    public async Task Can_Delete_A_Amenity()
    {
      var amenity = await CreateAndSaveNewAmenity();
      var repository = new AmenityRepository(_db);
      await repository.DeleteAmenity(1);
      var retAmenity = await repository.GetAmenities();
      Assert.DoesNotContain(retAmenity, e => e.Name == "Replicator");
    }
    [Fact]
    public async Task Can_Edit_A_Amenity()
    {
      var repository = new AmenityRepository(_db);
      var amenity = await CreateAndSaveNewAmenity();
      await repository.UpdateAmenity(1, new AsyncInn.Models.Amenity { ID = 2, Name = "Locker" });
      await repository.DeleteAmenity(1);
      var PutAmenity = await repository.GetAmenities();
      Assert.Contains(PutAmenity, e => e.Name == "Locker");
    }
    [Fact]
    public async Task Can_Get_An_Amenity()
    {
      var repository = new AmenityRepository(_db);
      var GetAmenity = await repository.GetAmenity(2);
      Assert.Equal("Mini-Bar", GetAmenity.Name);
    }
    [Fact]
    public async Task Can_Update_A_Hotel_Room() {  
    
      var repo = new HotelRoomRepository(_db);
      await CreateAndSaveHotelRoom();
      await CreateAndSaveANewRoomType();
      await CreateAndSaveANewHotel();
      var newHotelRoom = new AsyncInn.Models.HotelRoom
      {
        HotelID = 2,
        RoomNumber = 1234,
        RoomID = 1,
        Rate = 500.00M,
        PetFriendly = true
      };

      await repo.UpdateHotelRoom(4, 224, newHotelRoom);
      _db.Entry(newHotelRoom).State = EntityState.Detached;
      //await repo.DeleteHotelRoom(2, 1234);
      var putHotelRoom = await repo.GetHotelRoom(2, 1234);
      Assert.True(putHotelRoom.PetFriendly);        
    }
  }
}
