using AsyncInn.Data;
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
      RoomAmenities roomAmenity = new RoomAmenities()
      {
        RoomId = id,
        AmenityId = amenityid
      };
      _context.Entry(roomAmenity).State = EntityState.Added;
      await _context.SaveChangesAsync();
    }

    public async Task<Room> Create(Room room)
    {
      _context.Entry(room).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return room;
    }

    public async Task DeleteRoom(int id)
    {
      Room room = await GetRoom(id);
      _context.Remove(room).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<Room> GetRoom(int Id)
    {      
      Room room = await _context.Room.FindAsync(Id);
      var amenities = await _context.RoomAmenities.Where(x => x.RoomId == Id)
                                                  .Include(x => x.Amenities)
                                                  .ToListAsync();

      room.Amenities = amenities;                                                    
      return room;

    }

    public async Task<List<Room>> GetRooms()
    {
      var rooms = await _context.Room.ToListAsync();
      return rooms;
    }

    public async Task RemoveAmenityFromRoom(int roomid, int amenityid)
    {
      var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomId == roomid && x.AmenityId == amenityid);
      _context.Entry(result).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<Room> UpdateRoom(int id, Room room)
    {
      _context.Entry(room).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return room;
    }


  }
}
