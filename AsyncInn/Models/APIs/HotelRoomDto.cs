namespace AsyncInn.Models.APIs
{
  public class HotelRoomDto
  {
    public int HotelID { get; set; }
    public int RoomNumber { get; set; }
    public decimal Rate { get; set; }
    public bool PetFriendly { get; set; }
    public int RoomID { get; set; }
    public RoomDto Room { get; set; }
  }


}
