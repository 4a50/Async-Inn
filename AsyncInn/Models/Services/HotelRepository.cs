﻿using AsyncInn.Data;
using AsyncInn.Models.APIs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static AsyncInn.Models.APIs.HotelRoomDto;

namespace AsyncInn.Models.Interfaces.Services
{
  public class HotelRepository : IHotel
  {
    private AsyncInnDbContext _context;

    public HotelRepository(AsyncInnDbContext context)
    {
      _context = context;
    }
    /// <summary>
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
      { PetFriendly = false, Rate = 0.00M, HotelID = hotel.Id, RoomNumber = roomNumber, RoomID = 1,
      Room = room};    

      _context.Entry(newHotelRoom).State = EntityState.Added;

      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Creates a NEW hotel
    /// </summary>
    /// <param name="hotel"></param>
    /// <returns></returns>
    public async Task<Hotel> Create(Hotel hotel)
    {
      _context.Entry(hotel).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return hotel;

    }
    /// <summary>
    /// Removes a Hotel From the Database
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public async Task DeleteHotel(int ID)
    {
      HotelDto hotel = await GetHotel(ID);
      _context.Remove(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Get All Room associated with a given Hotel
    /// </summary>
    /// <param name="hotelId"></param>
    /// <returns></returns>
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
    /// Gets information for a given hotel ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public async Task<HotelDto> GetHotel(int ID)
    {
      return await _context.Hotel //HotelModel
     .Select(hotel => new HotelDto
     {
       Id = hotel.Id,
       Name = hotel.Name,
       StreetAddress = hotel.StreetAddress,
       City = hotel.City,
       State = hotel.State,
       Phone = hotel.Phone,
       //Within the Hotel model, select the HotelRoom and make a DTO
       Rooms = hotel.HotelRoom.Select(hr => new HotelRoomDto
       {
         HotelID = hr.HotelID,
         RoomID = hr.RoomID,
         Rate = hr.Rate,
         PetFriendly = hr.PetFriendly,
         RoomNumber = hr.RoomNumber,
         //Within the hotel.hotelroom, make a room.dto
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
       }).ToList()
     }).FirstOrDefaultAsync(au => (au.Id == ID));


      //Hotel hotel = await _context.Hotel.FindAsync(ID);
      //return hotel;
    }
    /// <summary>
    /// Get a list of all hotels
    /// </summary>
    /// <returns></returns>
    public async Task<List<HotelDto>> GetHotels()
    {
      return await _context.Hotel //HotelModel
     .Select(hotel => new HotelDto
     {
       Id = hotel.Id,
       Name = hotel.Name,
       StreetAddress = hotel.StreetAddress,
       City = hotel.City,
       State = hotel.State,
       Phone = hotel.Phone,
       //Within the Hotel model, select the HotelRoom and make a DTO
       Rooms = hotel.HotelRoom.Select(hr => new HotelRoomDto
       {
         HotelID = hr.HotelID,
         RoomID = hr.RoomID,
         Rate = hr.Rate,
         PetFriendly = hr.PetFriendly,
         RoomNumber = hr.RoomNumber,
         //Within the hotel.hotelroom, make a room.dto
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
       }).ToList()
     }).ToListAsync();


      //var hotels = await _context.Hotel.ToListAsync();
      //return hotels;
    }
    /// <summary>
    /// Updated the information for a given hotel.
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="hotel"></param>
    /// <returns></returns>
    public async Task<Hotel> UpdateHotel(int ID, Hotel hotel)
    {
      _context.Entry(hotel).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return hotel;
    }
    /// <summary>
    /// Updates the details in a Room in a Hotel
    /// </summary>
    /// <param name="hotelID"></param>
    /// <param name="roomNumebr"></param>
    /// <param name="hotelRoom"></param>
    /// <returns></returns>
    public async Task<HotelRoom>UpdateHotelRoom(int hotelID, int roomNumber, HotelRoom hotelRoom)
    {
      Debug.WriteLine("Route Selected");
      _context.Entry(hotelRoom).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return hotelRoom;
    }
    public async Task DeleteHotelRoom(int hotelId, int roomNumber)
    {
      HotelRoom hotelRoom = await GetRoomDetails(hotelId, roomNumber);
      _context.Remove(hotelRoom).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }
  }
}