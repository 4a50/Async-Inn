using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
  public class Room
  {
    public int ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Layout { get; set; }
    //One (Room) to Many (Amenities)
    public List<RoomAmenities> Amenities { get; set; }
  }
}
