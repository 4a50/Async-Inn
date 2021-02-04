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
    /// <summary>
    /// Creates a New Ammenity
    /// </summary>
    /// <param name="inboundAmenity"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Deletes an Ammenity
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public async Task DeleteAmenity(int ID)
    {     
      AmenityDto amenityDto = await GetAmenity(ID);
      Amenity amenity = new Amenity { ID = amenityDto.ID };
      _context.Remove(amenity).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Gets a list of Amenities
    /// </summary>
    /// <returns></returns>
    public async Task<List<AmenityDto>> GetAmenities()
    {
      return await _context.Amenities
        .Select(amenity => new AmenityDto
        {
          ID = amenity.ID,
          Name = amenity.Name
        }).ToListAsync();      
    }
    /// <summary>
    /// Gets an individual Amenity
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public async Task<AmenityDto> GetAmenity(int ID)
    {      
      return await _context.Amenities
        .Select(am => new AmenityDto
        {
          ID = am.ID,
          Name = am.Name
        }).FirstOrDefaultAsync(i => (i.ID == ID));
          
    }
    /// <summary>
    /// Updates an existing amenity
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="amenity"></param>
    /// <returns></returns>
    public async Task<Amenity> UpdateAmenity(int ID, Amenity amenity)
    {
      _context.Entry(amenity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return amenity;
    }
  }
}
