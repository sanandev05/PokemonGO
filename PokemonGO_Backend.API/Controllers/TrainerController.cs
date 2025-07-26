using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;

namespace PokemonGO_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _trainerService.GetAll();
            if (!trainers.Any()) return NotFound();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var trainer = await _trainerService.GetById(id);
            if (trainer == null) return NotFound();
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainerDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _trainerService.AddAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrainerDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _trainerService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _trainerService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
