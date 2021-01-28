using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces { 

    public interface IAmenity
    {
        Task<Amenity> Create(Amenity amenity);
        Task<Amenity> GetAmenity(int ID);
        Task<List<Amenity>> GetAmenities();
        Task<Amenity> UpdateAmenity(int ID, Amenity amenity);
        Task DeleteAmenity(int ID);
    }
}
