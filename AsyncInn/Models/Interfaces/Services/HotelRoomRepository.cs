﻿using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    public async Task<HotelRoom> Create(HotelRoom hotelRoom)
    {
      _context.Entry(hotelRoom).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return hotelRoom;
    }

    public async Task<HotelRoom> GetHotelRoom(int hotelid, int roomid)
    {
      //this will find the record for the hotel and RoomId.

      HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(hotelid, roomid);
      return hotelRoom;
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
    public async Task DeleteHotelRoom(int hotelid, int roomid)
    {
      HotelRoom hotelRoom = await GetHotelRoom(hotelid, roomid);
      _context.Entry(hotelRoom).State = EntityState.Deleted;
    }
  }
}
