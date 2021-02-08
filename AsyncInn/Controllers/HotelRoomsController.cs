using AsyncInn.Models;
using AsyncInn.Models.APIs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
  [Route("api/Hotels")]
  [ApiController]
  public class HotelRoomsController : ControllerBase
  {
    private readonly IHotelRoom _hotelRoom;

    public HotelRoomsController(IHotelRoom hotelRoom)
    {
      _hotelRoom = hotelRoom;
    }

    /// <summary>
    /// GET: api/HotelRooms
    /// Get A List of all the Rooms in a hotel
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom()
    {
      return Ok(await _hotelRoom.GetAllRoomsHotel());
    }

    /// <summary>
    /// GET: api/HotelRooms/5
    /// Get an individual Hotel Room in a Given Hotel using a RoomNumber
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="roomId"></param>
    /// <returns></returns>
    [HttpGet("{hotelId}/Rooms/{roomId}")]
    [AllowAnonymous]
    public async Task<ActionResult<HotelRoomDto>> GetHotelRoom(int hotelId, int roomId)
    {
      var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomId);

      if (hotelRoom == null)
      {
        return NotFound();
      }

      return hotelRoom;
    }
    /// <summary>
    /// Get the Room Details of a specific Room in a selected Hotel
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="roomNumber"></param>
    /// <returns></returns>
    //Get: api/Hotels/3/Rooms/3

    [HttpGet]
    [Route("{hotelId}/Rooms/{roomNumber}")]
    [AllowAnonymous]
    public async Task<ActionResult<Hotel>> GetRoomDetails(int hotelId, int roomNumber)
    {
      return Ok(await _hotelRoom.GetRoomDetails(hotelId, roomNumber));
    }

    /// <summary>
    /// Adds a Room to a Given Hotel
    /// Post: api/Hotels/1/Rooms/3
    /// </summary>
    /// <param name="hotelID"></param>
    /// <param name="roomNumber"></param>
    /// <returns></returns>


    [HttpPost]
    [Route("{hotelID}/Rooms/{roomNumber}")]
    [Authorize(Policy ="b")]
    public async Task<ActionResult<HotelRoom>> AddHotelRoom(int hotelID, int roomNumber)
    {
      await _hotelRoom.AddHotelRoom(hotelID, roomNumber);
      return NoContent();
    }
    /// <summary>

    /// <summary>
    ///  api/HotelRooms    
    ///  Creates a NEW Hotel Room for a given hotel
    /// </summary>
    /// <param name="hotelRoom"></param>
    /// <returns></returns>

    [HttpPost]
    [Authorize(Policy="b")]
    public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoomDto hotelRoom)
    {
      await _hotelRoom.Create(hotelRoom);
      return CreatedAtAction("Get HotelRoom", hotelRoom);
    }
    /// <summary>
    /// PUT: api/HotelRooms/5    
    /// Updates A Hotel Room given a HotelID and RoomNumber
    /// </summary>
    /// <param name="hotelid"></param>
    /// <param name="roomid"></param>
    /// <param name="hotelRoom"></param>
    /// <returns></returns>    
    [HttpPut("{hotelid}/Rooms/{roomNumber}")]
    [Authorize(Policy="c")]
    public async Task<IActionResult> PutHotelRoom(int hotelid, int roomNumber, HotelRoom hotelRoom)
    {
      if (hotelid != hotelRoom.HotelID && roomNumber != hotelRoom.RoomID)
      {
        return BadRequest();
      }

      var updatedRoom = await _hotelRoom.UpdateHotelRoom(hotelid, roomNumber, hotelRoom);
      return Ok(updatedRoom);
    }

    /// <summary>
    /// Removes a HotelRoom from a Hotel 
    /// DELETE: api/Hotels/1/232
    /// </summary>
    /// <param name="holelId"></param>
    /// <param name="roomNumber"></param>
    /// <returns></returns>

    [HttpDelete("{hotelId}/{roomNumber}")]
    [Authorize(Policy ="a")]
    public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int holelId, int roomNumber)
    {

      await _hotelRoom.DeleteHotelRoom(holelId, roomNumber);
      return NoContent();
    }

  }
}
