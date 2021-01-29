using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
  public interface IRoom
  {
    Task<Room> Create(Room room);
    Task<Room> GetRoom(int Id);
    Task<List<Room>> GetRooms();
    Task<Room> UpdateRoom(int id, Room room);
    Task DeleteRoom(int id);

    Task AddAmenityToRoom(int id, int amenityid);
    Task RemoveAmenityFromRoom(int roomid, int amenityid);
  }
}
