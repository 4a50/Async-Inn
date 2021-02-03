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
    public async Task Can_Add_A_New_Hotel_Room()
    {
      var hotel = await CreateAndSaveNewHotel();
      var room = await CreateAndSaveANewRoomType();

      var repository = new HotelRepository(_db);

   
    }
  }
}
