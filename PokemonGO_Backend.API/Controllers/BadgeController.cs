using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : Controller
    {
        private readonly IGenericService<Badge, BadgeDTO> _service;
        public BadgeController(IGenericService<Badge, BadgeDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var badges = await _service.GetAllAsync();
            if (!badges.Any()) return NotFound();

            return Ok(badges);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var badge = await _service.GetByIdAsync(id);
            if (badge == null) return NotFound();

            return Ok(badge);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BadgeDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdBadge = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = createdBadge.Id }, createdBadge);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BadgeDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedBagde = await _service.UpdateAsync(dto);
            if (updatedBagde == null) return NotFound();

            return Ok(updatedBagde);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _service.DeleteAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
