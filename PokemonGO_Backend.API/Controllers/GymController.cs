using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGenericService<Gym, GymDTO> _service;
        private readonly IGymService _gymService;
        public GymController(IGenericService<Gym, GymDTO> service, IGymService gymService)
        {
            _service = service;
            _gymService = gymService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gyms = await _service.GetAllAsync();
            if (!gyms.Any()) return NotFound();

            return Ok(gyms);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var gym = await _service.GetByIdAsync(id);
            if (gym == null) return NotFound();

            return Ok(gym);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GymDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdGym = await _gymService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = createdGym.Id }, createdGym);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GymDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedGym = await _gymService.UpdateAsync(id, dto);
            if (updatedGym == null) return NotFound();

            return Ok(updatedGym);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _gymService.DeleteAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
