using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotelRoom
  {
    Task<HotelRoom> Create(HotelRoom hotelRoom);
    Task<List<HotelRoom>> GetAllRoomsHotel();
    Task<HotelRoom> GetHotelRoom(int hotelid, int roomid);

    Task<HotelRoom> UpdateHotelRoom(int hotelid, int roomid, HotelRoom hotelRoom);
    Task DeleteHotelRoom(int hotelid, int roomid);
  }
}
//Skip the primary key.  Define it as HotelID.
//