using AsyncInn.Data;
using AsyncInn.Models.APIs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
  public class RoomRepository : IRoom
  {
    private AsyncInnDbContext _context;

    public RoomRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task AddAmenityToRoom(int id, int amenityid)
    {
      RoomAmenity roomAmenity = new RoomAmenity()
      {
        RoomId = id,
        AmenityId = amenityid
      };
      _context.Entry(roomAmenity).State = EntityState.Added;
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Creates a New Room Type
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    public async Task<Room> Create(RoomDto room)
    {
      Room rm = new Room
      {
        ID = room.ID,
        Name = room.Name,
        Layout = room.Layout
      };
      _context.Entry(rm).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return rm;
    }
    /// <summary>
    /// Deletes a Room Type
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteRoom(int id)
    {
      RoomDto roomDto = await GetRoom(id);
      Room room = new Room
      {
        ID = roomDto.ID,
        Name = roomDto.Name,
        Layout = roomDto.Layout
      };
      _context.Remove(room).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Get a Room type
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public async Task<RoomDto> GetRoom(int Id)
    {
      return await _context.Room.Select(r => new RoomDto
      {
        ID = r.ID,
        Layout = r.Layout,
        Name = r.Name,
        Amenities = r.Amenities.Select(a => new AmenityDto
        {
          ID = a.Amenities.ID,
          Name = a.Amenities.Name
        }).ToList()
      }).FirstOrDefaultAsync(x => (x.ID == Id));
    }
    /// <summary>
    /// Gets a list of all the room types
    /// </summary>
    /// <returns></returns>
    public async Task<List<RoomDto>> GetRooms()
    {
      return await _context.Room.Select(r => new RoomDto
      {
        ID = r.ID,
        Name = r.Name,
        Layout = r.Layout,
        Amenities = r.Amenities.Select(ra => new AmenityDto
        {
          ID = ra.Amenities.ID,
          Name = ra.Amenities.Name
        }).ToList()
      }).ToListAsync();
    }
    /// <summary>
    /// Removes an Amenity From a Room Type
    /// </summary>
    /// <param name="roomid"></param>
    /// <param name="amenityid"></param>
    /// <returns></returns>   
    public async Task RemoveAmenityFromRoom(int roomid, int amenityid)
    {
      var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == roomid && x.AmenityId == amenityid);
      _context.Entry(result).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Updates a Room Type's information.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="room"></param>
    /// <returns></returns>
    public async Task<RoomDto> UpdateRoom(int id, RoomDto room)
    {
      Room updatedRoom = new Room
      {
        ID = room.ID,
        Name = room.Name,
        Layout = room.Layout

      };
      
      _context.Entry(updatedRoom).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return room;
    }

    
  }
}
