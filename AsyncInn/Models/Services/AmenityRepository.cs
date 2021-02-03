using AsyncInn.Data;
using AsyncInn.Models.APIs;
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
    //Post
    public async Task<Amenity> Create(AmenityDto inboundAmenity)
    {
      Amenity amenity = new Amenity
      {
        Name = inboundAmenity.Name
      };
      _context.Entry(amenity).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return amenity;
    }
    //Delete
    public async Task DeleteAmenity(int ID)
    {     
      AmenityDto amenityDto = await GetAmenity(ID);
      Amenity amenity = new Amenity { ID = amenityDto.ID };
      _context.Remove(amenity).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
    //Get
    public async Task<List<AmenityDto>> GetAmenities()
    {
      return await _context.Amenities
        .Select(amenity => new AmenityDto
        {
          ID = amenity.ID,
          Name = amenity.Name
        }).ToListAsync();      
    }

    public async Task<AmenityDto> GetAmenity(int ID)
    {
      //Amenity amenity = await _context.Amenities.FindAsync(ID);
      //var room = await _context.RoomAmenities.Where(x => x.AmenityId == ID)
      //                                       .Include(x => x.Room)
      //                                       .ToListAsync();
      //amenity.Rooms = room;
      return await _context.Amenities
        .Select(am => new AmenityDto
        {
          ID = am.ID,
          Name = am.Name
        }).FirstOrDefaultAsync(i => (i.ID == ID));
          
    }
    //PUT
    public async Task<Amenity> UpdateAmenity(int ID, Amenity amenity)
    {
      _context.Entry(amenity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return amenity;
    }
  }
}
