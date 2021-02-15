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
    public List<RoomAmenity> Amenities { get; set; }
    public List<Room> HotelRoom { get; set; }

  }
}
