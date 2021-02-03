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

    public async Task<List<HotelRoom>> GetAllRoomsHotel()
    {
      var allRooms = await _context.HotelRoom.ToListAsync();
      return allRooms;
    }

    public async Task<HotelRoom> UpdateHotelRoom(int hotelid, int roomid, HotelRoom hotelRoom)
    {
      _context.Entry(hotelRoom).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return hotelRoom;
    }
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
