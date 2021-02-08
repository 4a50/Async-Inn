using AsyncInn.Models;
using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HotelController : ControllerBase
  {
    private readonly IHotel _hotel;

    public HotelController(IHotel hotel)
    {
      _hotel = hotel;
    }
    /// <summary>
    /// Gets a list of all the hotels
    /// </summary>
    /// <returns></returns>
    //GET: api/Hotels
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotel()
    {
      List<HotelDto> hdt = await _hotel.GetHotels();
      Debug.WriteLine($"HotelDTO Count: {hdt.Count}");
      return Ok(hdt);
    }
    /// <summary>
    /// Gets the information for a given hotel
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //GET: api/Hotels/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<HotelDto>> GetHotel(int id)
    {
      var hotel = await _hotel.GetHotel(id);

      if (hotel == null)
      {
        return NotFound();
      }

      return hotel;
    }
    /// <summary>
    /// Get all rooms in the Hotel
    /// </summary>
    /// <param name="hotelId"></param>
    /// <returns></returns>
    //Get: api/Hotels/2/Rooms
    [HttpGet]
    [AllowAnonymous]
    [Route("{hotelId}/Rooms")]
    public async Task<ActionResult<Hotel>> GetAllRoomsInHotel(int hotelId)
    {
      return Ok(await _hotel.GetAllRoomsInHotel(hotelId));
    }
   


    /// <summary>
    /// Updates the information for a specified hotel
    /// </summary>
    /// <param name="id"></param>
    /// <param name="hotel"></param>
    /// <returns></returns>
    //PUT: api/Hotels/5     
    [HttpPut("{id}")]
    [Authorize(Policy="a")]
    public async Task<IActionResult> PutHotel(int id, Hotel hotel)
    {
      if (id != hotel.Id)
      {
        return BadRequest();
      }
      var updatedHotel = await _hotel.UpdateHotel(id, hotel);
      return Ok(updatedHotel);
    }
   
    /// Creates a new Hotel
    /// </summary>
    /// <param name="hotel"></param>
    /// <returns></returns>
    // POST: api/Hotels    
    [HttpPost]
    [Authorize(Policy ="a")]
    public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
    {
      await _hotel.Create(hotel);
      return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }
    /// <summary>
    /// Deletes a Hotel
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // DELETE: api/Hotels/5    
    [HttpDelete("{id}")]
    [Authorize(Policy ="a")]
    public async Task<ActionResult<Hotel>> DeleteHotel(int id)
    {
      await _hotel.DeleteHotel(id);
      return NoContent();
    }
    /// <summary>
    /// Updates a specific Hotel Room
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="roomNumber"></param>
    /// <param name="hotelRoom"></param>
    /// <returns></returns>
    
    [HttpPut]
    [Route("{hotelId}/Rooms/{roomNumber}")]
    [Authorize(Policy="b")]
    public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom)
    {
      if (hotelId != hotelRoom.HotelID || roomNumber != hotelRoom.RoomNumber)
      {
        return BadRequest();
      }

      var updatedHotelRoom = await _hotel.UpdateHotelRoom(hotelId, roomNumber, hotelRoom);
      return Ok(updatedHotelRoom);
    }
  }
}
