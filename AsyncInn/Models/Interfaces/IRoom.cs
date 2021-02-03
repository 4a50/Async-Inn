using AsyncInn.Models.APIs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IRoom
  {
    Task<Room> Create(RoomDto room);
    Task<RoomDto> GetRoom(int Id);
    Task<List<RoomDto>> GetRooms();
    Task<RoomDto> UpdateRoom(int id, RoomDto room);
    Task DeleteRoom(int id);

    Task AddAmenityToRoom(int id, int amenityid);
    Task RemoveAmenityFromRoom(int roomid, int amenityid);
  }
}
