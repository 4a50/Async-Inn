using AsyncInn.Data;
using AsyncInn.Models.APIs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
  public class HotelRoomRepository : IHotelRoom
  {
    private AsyncInnDbContext _context;
    public HotelRoomRepository(AsyncInnDbContext context)
    {
      _context = context;
    }
    /// <summary>
    /// CREATE: Creates a new Room for a Hotel
    /// </summary>
    /// <param name="hrDto"></param>
    /// <returns></returns>
    public async Task<HotelRoom> Create(HotelRoomDto hrDto)
    {
      HotelRoom hotelRoom = new HotelRoom
      {
        HotelID = hrDto.HotelID,
        RoomID = hrDto.RoomID,
        RoomNumber = hrDto.RoomNumber,
        Rate = hrDto.Rate,
        PetFriendly = hrDto.PetFriendly,
      };

      _context.Entry(hotelRoom).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return hotelRoom;
    }
    /// Adds A New Hotel Room to the Hotel
    /// </summary>
    /// <param name="hotelID"></param>
    /// <param name="roomNumber"></param>
    /// <returns></returns>
    public async Task AddHotelRoom(int hotelID, int roomNumber)
    {
      Hotel hotel = await _context.Hotel.FindAsync(hotelID);
      Room room = await _context.Room.FindAsync(2);

      HotelRoom newHotelRoom = new HotelRoom()
      {
        PetFriendly = false,
        Rate = 0.00M,
        HotelID = hotel.Id,
        RoomNumber = roomNumber,
        RoomID = 1,
        Room = room
      };

      _context.Entry(newHotelRoom).State = EntityState.Added;

      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Retrieves the details of a room in a given hotel
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="roomNumber"></param>
    /// <returns></returns>
    public async Task<HotelRoom> GetRoomDetails(int hotelId, int roomNumber)
    {
      HotelRoom hotelRoom = await _context.HotelRoom.FirstOrDefaultAsync(
                             x => x.HotelID == hotelId && x.RoomNumber == roomNumber);
      return hotelRoom;
    }


    /// <summary>
    /// GET: Get's an individual HotelRoom
    /// </summary>
    /// <param name="hotelid"></param>
    /// <param name="roomNumber"></param>
    /// <returns></returns>
    public async Task<HotelRoomDto> GetHotelRoom(int hotelid, int roomNumber)
    {
      //this will find the record for the hotel and RoomId.
      return await _context.HotelRoom
        .Select(hr => new HotelRoomDto
        {
          HotelID = hr.HotelID,
          RoomID = hr.RoomID,
          PetFriendly = hr.PetFriendly,
          Rate = hr.Rate,
          RoomNumber = hr.RoomNumber,
          Room = new RoomDto
          {
            ID = hr.Room.ID,
            Name = hr.Room.Name,
            Layout = hr.Room.Layout,
            Amenities = hr.Room.Amenities.Select(a => new AmenityDto
            {
              ID = a.Amenities.ID,
              Name = a.Amenities.Name
            }).ToList()
          }
        }).FirstOrDefaultAsync(x => (x.HotelID == hotelid && x.RoomNumber == roomNumber));
    }
    /// <summary>
    /// GET: Returns a list of all Rooms in a Hotel
    /// </summary>
    /// <returns></returns>
    public async Task<List<HotelRoom>> GetAllRoomsHotel()
    {
      var allRooms = await _context.HotelRoom.ToListAsync();
      return allRooms;
    }
    /// <summary>
    /// PUT: Updates a Hotel Room.
    /// </summary>
    /// <param name="hotelid"></param>
    /// <param name="roomid"></param>
    /// <param name="hotelRoom"></param>
    /// <returns></returns>
    public async Task<HotelRoom> UpdateHotelRoom(int hotelid, int roomid, HotelRoom hotelRoom)
    {
      _context.Entry(hotelRoom).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return hotelRoom;
    }
    /// <summary>
    /// Delete: Deletes a hotel room
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="roomNumber"></param>
    /// <returns></returns>
    public async Task DeleteHotelRoom(int hotelId, int roomNumber)
    {
      HotelRoomDto hrDto = await GetHotelRoom(hotelId, roomNumber);
      HotelRoom hotelRoom = new HotelRoom
      {
        HotelID = hotelId,
        RoomID = hrDto.RoomID,
        RoomNumber = roomNumber,
        Rate = hrDto.Rate,
        PetFriendly = hrDto.PetFriendly,
      };
      _context.Remove(hotelRoom).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
  }
}
