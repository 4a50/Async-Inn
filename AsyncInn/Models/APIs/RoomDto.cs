using System.Collections.Generic;

namespace AsyncInn.Models.APIs
{
  public class RoomDto
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int Layout { get; set; }    
    public List<AmenityDto> Amenities {get; set;}
  }


}
