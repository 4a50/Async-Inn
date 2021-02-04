using AsyncInn.Models;
using AsyncInn.Models.APIs;
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

    /// <summary>
    /// GET: api/Rooms
    /// Get a list of All Room Types
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
    {
      return Ok(await _room.GetRooms());
    }

    /// <summary>
    /// GET: api/Rooms/5
    /// Gets information on an individual room.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDto>> GetRoom(int id)
    {
      var room = await _room.GetRoom(id);

      if (room == null)
      {
        return NotFound();
      }

      return room;
    }

    /// <summary>
    /// PUT: api/Rooms/5
    /// Updates and Exsisting Room Type given a proper ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="room"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(int id, RoomDto room)
    {
      if (id != room.ID)
      {
        return BadRequest();
      }

      var updatedRoom = await _room.UpdateRoom(id, room);
      return Ok(updatedRoom);
    }


    /// <summary>
    /// POST: api/Rooms
    /// Creates a new Room Type
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(RoomDto room)
    {
      await _room.Create(room);
      return CreatedAtAction("GetRoom", room);
    }

    /// <summary>
    /// POST: api/Rooms/2/Amenity/3
    /// Add an Amenity to a Room.
    /// </summary>
    /// <param name="roomid"></param>
    /// <param name="amenityId"></param>
    /// <returns></returns>

    [HttpPost]
    [Route("{roomid}/Amenity/{amenityId}")]
    public async Task<ActionResult<Room>> AddAmenityToRoom(int roomid, int amenityId)
    {
      await _room.AddAmenityToRoom(roomid, amenityId);
      return NoContent();
    }

    /// <summary>
    /// DELETE: /api/Rooms/3/2
    /// Deletes an Amenity from a room type
    /// </summary>
    /// <param name="id"></param>
    /// <param name="amenityId"></param>
    /// <returns></returns>
    [HttpDelete("{id}/Amenity/{amenityId}")]
    public async Task<ActionResult<Room>> RemoveAmenityFromRoom(int id, int amenityId)
    {
      await _room.RemoveAmenityFromRoom(id, amenityId);
      return NoContent();
    }

    /// <summary>
    /// DELETE: api/Rooms/5
    /// Deletes a Room Type
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Room>> DeleteRoom(int id)
    {
      await _room.DeleteRoom(id);
      return NoContent();
    }
  }
}

