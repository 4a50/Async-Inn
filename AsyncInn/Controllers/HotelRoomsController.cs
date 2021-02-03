using AsyncInn.Models;
using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HotelRoomsController : ControllerBase
  {
    private readonly IHotelRoom _hotelRoom;

    public HotelRoomsController(IHotelRoom hotelRoom)
    {
      _hotelRoom = hotelRoom;
    }

    // GET: api/HotelRooms
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom()
    {
      return Ok(await _hotelRoom.GetAllRoomsHotel());
    }

    // GET: api/HotelRooms/5
    [HttpGet("{id}/{roomId}")]
    public async Task<ActionResult<HotelRoomDto>> GetHotelRoom(int hotelId, int roomId)
    {
      var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomId);

      if (hotelRoom == null)
      {
        return NotFound();
      }

      return hotelRoom;
    }

    // PUT: api/HotelRooms/5    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotelRoom(int hotelid, int roomid, HotelRoom hotelRoom)
    {
      if (hotelid != hotelRoom.HotelID && roomid != hotelRoom.RoomID)
      {
        return BadRequest();
      }

      var updatedRoom = await _hotelRoom.UpdateHotelRoom(hotelid, roomid, hotelRoom);
      return Ok(updatedRoom);
    }

    // POST: api/HotelRooms    
    [HttpPost]
    public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoomDto hotelRoom)
    {
      await _hotelRoom.Create(hotelRoom);
      return CreatedAtAction("Get HotelRoom", hotelRoom);
    }
    // DELETE: api/HotelRooms/5
    [HttpDelete("{hotelId}/{roomId}")]
    public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int holelId, int roomid)
    {
      await _hotelRoom.DeleteHotelRoom(holelId, roomid);
      return NoContent();
    }
  }
}
