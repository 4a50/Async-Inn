using AsyncInn.Models.APIs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotelRoom
  {
    Task<HotelRoom> Create(HotelRoomDto hotelRoom);
    Task<List<HotelRoom>> GetAllRoomsHotel();
    Task<HotelRoomDto> GetHotelRoom(int hotelid, int roomid);

    Task<HotelRoom> UpdateHotelRoom(int hotelid, int roomid, HotelRoom hotelRoom);
    Task DeleteHotelRoom(int hotelid, int roomid);
  }
}
//Skip the primary key.  Define it as HotelID.
//