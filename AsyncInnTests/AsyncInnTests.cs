using AsyncInn.Models;
using AsyncInn.Models.Interfaces.Services;
using System;
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
  }
}
