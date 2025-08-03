using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IGenericService<Pokemon,PokemonDTO> _service;
        private IPokemonService _pokemonService;
        public PokemonController(IGenericService<Pokemon, PokemonDTO> service, IPokemonService pokemonService)
        {
            _service = service;
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas =await _service.GetAllAsync();
            if(!datas.Any()) return NotFound();
            
            return Ok(datas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if(data == null) return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PokemonDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            foreach (var abilityId in dto.AbilityIds)
            {
                if (abilityId <= 0)
                {
                    ModelState.AddModelError("AbilityIds", "Ability ID must be greater than zero.");
                    return BadRequest(ModelState);
                }
            }
            await _pokemonService.AddAsync(dto);
            return Ok(dto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<PokemonDTO>> Update([FromBody] PokemonDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = await _pokemonService.UpdateAsync(dto);
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
