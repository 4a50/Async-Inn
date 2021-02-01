using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
  public class HotelRepository : IHotel
  {
    private AsyncInnDbContext _context;

    public HotelRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task AddHotelRoom(int hotelID, int roomNumber)
    {      
      Hotel hotel = await _context.Hotel.FindAsync(hotelID);
     
      HotelRoom newHotelRoom = new HotelRoom()
      { PetFriendly = false,  Rate = 0.00M, HotelID = hotel.Id, RoomNumber = roomNumber, RoomID = 1};    
      _context.Entry(newHotelRoom).State = EntityState.Added;

      await _context.SaveChangesAsync();
    }

    public async Task<Hotel> Create(Hotel hotel)
    {
      _context.Entry(hotel).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return hotel;

    }


    public async Task DeleteHotel(int ID)
    {
      Hotel hotel = await GetHotel(ID);
      _context.Remove(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<List<HotelRoom>> GetAllRoomsInHotel(int hotelId)
    {
      //var hotel = await _context.Hotel.FindAsync(hotelId);
      var roomList = await _context.HotelRoom
          .Where(x => x.HotelID == hotelId)  
          .Include(x => x.Room)
          .ToListAsync();
      //hotel.HotelRoom = roomList;
      return roomList;
    }
    public async Task<HotelRoom> GetRoomDetails(int hotelId, int roomNumber)
    {
      HotelRoom hotelRoom = await _context.HotelRoom.FirstOrDefaultAsync(
                             x => x.HotelID == hotelId && x.RoomNumber == roomNumber);
      return hotelRoom;
    }

    public async Task<Hotel> GetHotel(int ID)
    {
      Hotel hotel = await _context.Hotel.FindAsync(ID);
      return hotel;
    }

    public async Task<List<Hotel>> GetHotels()
    {
      var hotels = await _context.Hotel.ToListAsync();
      return hotels;
    }


    public async Task<Hotel> UpdateHotel(int ID, Hotel hotel)
    {
      _context.Entry(hotel).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return hotel;
    }
  }
}