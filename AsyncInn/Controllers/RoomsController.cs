using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RoomsController : ControllerBase
  {
    private readonly IRoom _room;

    public RoomsController(IRoom room)
    {
      _room = room;
    }

    // GET: api/Rooms
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
    {
      return Ok(await _room.GetRooms());
    }

    // GET: api/Rooms/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
      var room = await _room.GetRoom(id);

      if (room == null)
      {
        return NotFound();
      }

      return room;
    }

    // PUT: api/Rooms/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(int id, Room room)
    {
      if (id != room.ID)
      {
        return BadRequest();
      }

      var updatedRoom = await _room.UpdateRoom(id, room);
      return Ok(updatedRoom);
    }

    // POST: api/Rooms
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(Room room)
    {
      await _room.Create(room);
      return CreatedAtAction("GetRoom", new { id = room.ID });
    }

    // POST: api/Rooms/2/Amenity/3
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    [Route("{roomid}/Amenity/{amenityId}")]
    public async Task<ActionResult<Room>> AddAmenityToRoom(int roomid, int amenityId)
    {
      await _room.AddAmenityToRoom(roomid, amenityId);
      return NoContent();
    }

    //DELETE: /api/Rooms/3/2
    [HttpDelete("{id}/Amenity/{amenityId}")]
    public async Task<ActionResult<Room>> RemoveAmenityFromRoom (int id, int amenityId)
    {
      await _room.RemoveAmenityFromRoom(id, amenityId);
      return NoContent();
    }

    // DELETE: api/Rooms/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Room>> DeleteRoom(int id)
    {
      await _room.DeleteRoom(id);
      return NoContent();
    }
  }
}

