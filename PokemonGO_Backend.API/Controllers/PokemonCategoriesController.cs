using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonCategoriesController : ControllerBase
    {
        private readonly IGenericService<PokemonCategory, PokemonCategoryDTO> _service;

        public PokemonCategoriesController(IGenericService<PokemonCategory, PokemonCategoryDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonCategoryDTO>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonCategoryDTO>> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PokemonCategoryDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PokemonCategoryDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var exists = await _service.GetByIdAsync(id);
            if (exists == null)
                return NotFound();

            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _service.GetByIdAsync(id);
            if (exists == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
