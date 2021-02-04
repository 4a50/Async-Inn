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
  public class AmenitiesController : ControllerBase
  {
    private readonly IAmenity _amenity;

    public AmenitiesController(IAmenity amenity)
    {
      _amenity = amenity;
    }

    /// <summary>
    ///  GET: api/Amenities/5
    ///  Get Individual Amenity
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<AmenityDto>> GetAmenity(int id)
    {
      var amenity = await _amenity.GetAmenity(id);

      if (amenity == null)
      {
        return NotFound();
      }

      return amenity;
    }
    /// <summary>
    ///  GET: api/Amenities
    ///  Returns a list of all amenities.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
    {
      return Ok(await _amenity.GetAmenities());
    }


    /// <summary>
    /// PUT: api/Amenities/5    
    /// Updates an Amenity with an ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="amenity"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
    {
      if (id != amenity.ID)
      {
        return BadRequest();
      }
      var updatedAmenity = await _amenity.UpdateAmenity(id, amenity);
      return Ok(updatedAmenity);

    }

    /// <summary>
    /// POST: api/Amenities
    /// Creates a new Amenity
    /// </summary>
    /// <param name="amenity"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<AmenityDto>> PostAmenity(AmenityDto amenity)
    {
      Amenity newAmenity = await _amenity.Create(amenity);

      return CreatedAtAction("GetAmenity", new { id = amenity.ID }, amenity);
    }

    /// <summary>
    /// DELETE: api/Amenities/5
    /// Deletes an Amenity from Amenity Table
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
    {
      await _amenity.DeleteAmenity(id);
      return NoContent();
    }
  }
}
