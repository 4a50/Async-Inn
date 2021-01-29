namespace AsyncInn.Models
{
  public class RoomAmenities
  {
    public int RoomId { get; set; }
    public int AmenityId { get; set; }

    //Navigation Properties
    public Amenity Amenities { get; set; }
    public Room Room { get; set; }

  }
}
