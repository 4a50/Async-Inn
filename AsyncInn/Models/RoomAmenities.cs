namespace AsyncInn.Models
{
  public class RoomAmenity
  {
    public int RoomId { get; set; }
    public int AmenityId { get; set; }

    //Navigation Properties
    public Amenity Amenities { get; set; }
    public Room Room { get; set; }

  }
}
