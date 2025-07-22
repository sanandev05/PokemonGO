using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonAbilityController : ControllerBase
    {
        public IGenericService<PokemonAbility, PokemonAbilityDTO> _service;

        public PokemonAbilityController(IGenericService<PokemonAbility, PokemonAbilityDTO> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonAbilityDTO>>> GetAll()
        {
            var datas=await _service.GetAllAsync();
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonAbilityDTO>> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonAbilityDTO>> Create([FromBody] PokemonAbilityDTO dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id },dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PokemonAbilityDTO>> Update([FromBody] PokemonAbilityDTO dto)
        {        
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = await _service.UpdateAsync(dto);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
