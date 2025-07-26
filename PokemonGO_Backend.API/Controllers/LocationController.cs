using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IGenericService<Location, LocationDTO> _locationService;

        public LocationController(IGenericService<Location, LocationDTO> locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _locationService.GetAllAsync();
            if (!locations.Any()) return NotFound();

            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null) return NotFound();

            return Ok(location);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LocationDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdLocation = await _locationService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = createdLocation.Id }, createdLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LocationDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedLocation = await _locationService.UpdateAsync(dto);
            if (updatedLocation == null) return NotFound();

            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _locationService.DeleteAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
