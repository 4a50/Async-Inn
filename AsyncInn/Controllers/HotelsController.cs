using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HotelsController : ControllerBase
  {
    private readonly IHotel _hotel;

    public HotelsController(IHotel hotel)
    {
      _hotel = hotel;
    }
    //GET: api/Hotels
   [HttpGet]
    public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
    {
      return Ok(await _hotel.GetHotels());
    }

    //GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Hotel>> GetHotel(int id)
    {
      var hotel = await _hotel.GetHotel(id);

      if (hotel == null)
      {
        return NotFound();
      }

      return hotel;
    }
    //Get: api/Hotels/2/Rooms
    [HttpGet]
    [Route("{hotelId}/Rooms")]
    public async Task<ActionResult<Hotel>> GetAllRoomsInHotel(int hotelId)
    {
      return Ok(await _hotel.GetAllRoomsInHotel(hotelId));
    }
    //PUT: api/Hotels/5     
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, Hotel hotel)
    {
      if (id != hotel.Id)
      {
        return BadRequest();
      }

      var updatedHotel = await _hotel.UpdateHotel(id, hotel);
      return Ok(updatedHotel);
    }
    // Post: api/Hotels/1/Rooms/3
    [HttpPost]
    [Route("{hotelID}/Rooms")]
    public async Task<ActionResult<HotelRoom>> AddHotelRoom(int hotelID)
    {
      await _hotel.AddHotelRoom(hotelID);
      return NoContent();
    }
    // POST: api/Hotels    
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
    {
      await _hotel.Create(hotel);
      return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
    }
    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Hotel>> DeleteHotel(int id)
    {
      await _hotel.DeleteHotel(id);
      return NoContent();
    }

  }
}
