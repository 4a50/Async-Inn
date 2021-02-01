using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotel
  {
    Task<Hotel> Create(Hotel hotel);
    Task<Hotel> GetHotel(int ID);
    Task<List<HotelRoom>> GetAllRoomsInHotel(int hotelId);
    Task<HotelRoom> GetRoomDetails(int hotelId, int roomNumber);
    Task<List<Hotel>> GetHotels();
    Task<Hotel> UpdateHotel(int ID, Hotel hotel);

    Task AddHotelRoom(int hotelID, int roomNumber);
    Task DeleteHotel(int ID);

  }
}
