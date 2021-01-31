using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotel
  {
    Task<Hotel> Create(Hotel hotel);
    Task<Hotel> GetHotel(int ID);
    Task<Hotel> GetAllRoomsInHotel(int hotelId);
    Task<List<Hotel>> GetHotels();
    Task<Hotel> UpdateHotel(int ID, Hotel hotel);

    Task AddHotelRoom(int hotelID);
    Task DeleteHotel(int ID);

  }
}
