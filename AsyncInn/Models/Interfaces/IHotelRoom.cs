using AsyncInn.Models.APIs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotelRoom
  {
    public Task<HotelRoom> Create(HotelRoomDto hrDto);
    public Task AddHotelRoom(int hotelID, int roomNumber);
    public Task<List<HotelRoom>> GetAllRoomsHotel();
    public Task<HotelRoom> GetRoomDetails(int hotelId, int roomNumber);
    Task<HotelRoomDto> GetHotelRoom(int hotelid, int roomid);

    Task<HotelRoom> UpdateHotelRoom(int hotelid, int roomid, HotelRoom hotelRoom);
    Task DeleteHotelRoom(int hotelid, int roomid);
  }
}
//Skip the primary key.  Define it as HotelID.
//