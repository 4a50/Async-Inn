using AsyncInn.Models.APIs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{

  public interface IAmenity
  {
    Task<Amenity> Create(AmenityDto amenity);
    Task<AmenityDto> GetAmenity(int ID);
    Task<List<AmenityDto>> GetAmenities();
    Task<Amenity> UpdateAmenity(int ID, Amenity amenity);
    Task DeleteAmenity(int ID);
  }
}
