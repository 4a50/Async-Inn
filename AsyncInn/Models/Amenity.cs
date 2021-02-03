using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
  public class Amenity
  {
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }

    public List<RoomAmenity> Rooms { get; set; }

  }
}
