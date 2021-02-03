using AsyncInn.Models.APIs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IHotel
  {
    //Create
    Task<Hotel> Create(Hotel hotel);
    Task<HotelDto> GetHotel(int ID);
    Task AddHotelRoom(int hotelID, int roomNumber);
    Task<HotelRoom> UpdateHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom);
    //Read
    Task<List<HotelRoom>> GetAllRoomsInHotel(int hotelId);
    Task<HotelRoom> GetRoomDetails(int hotelId, int roomNumber);
    Task<List<HotelDto>> GetHotels();
    //Update
    Task<Hotel> UpdateHotel(int ID, Hotel hotel);

    //Delete-Destroy
    Task DeleteHotel(int ID);
    Task DeleteHotelRoom(int hotelId, int roomId);
  }
}
