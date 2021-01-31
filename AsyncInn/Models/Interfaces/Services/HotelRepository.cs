using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    public async Task AddHotelRoom(int hotelID)
    {
      HotelRoom newHotelRoom = new HotelRoom()
      { HotelID = hotelID };

      _context.Entry(newHotelRoom).State = EntityState.Added;
      await _context.SaveChangesAsync();
    }

    public async Task<Hotel> Create(Hotel hotel)
    {
      _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
      return hotel;

    }


    public async Task DeleteHotel(int ID)
    {
      Hotel hotel = await GetHotel(ID);
      _context.Remove(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
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