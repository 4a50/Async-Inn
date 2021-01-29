using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
  public class AmenityRepository : IAmenity
  {
    private AsyncInnDbContext _context;

    public AmenityRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task<Amenity> Create(Amenity amenity)
    {
      _context.Entry(amenity).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return amenity;
    }

    public async Task DeleteAmenity(int ID)
    {
      Amenity amenity = await GetAmenity(ID);
      _context.Remove(amenity).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<List<Amenity>> GetAmenities()
    {
      var amenities = await _context.Amenities.ToListAsync();
      return amenities;
    }

    public async Task<Amenity> GetAmenity(int ID)
    {
      Amenity amenity = await _context.Amenities.FindAsync(ID);
      var room = await _context.RoomAmenities.Where(x => x.AmenityId == ID)
                                             .Include(x => x.Room)
                                             .ToListAsync();
      amenity.Rooms = room;
      return amenity;
    }

    public async Task<Amenity> UpdateAmenity(int ID, Amenity amenity)
    {
      _context.Entry(amenity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return amenity;
    }
  }
}
