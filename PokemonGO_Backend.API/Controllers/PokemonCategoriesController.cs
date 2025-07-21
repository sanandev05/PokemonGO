using Microsoft.AspNetCore.Mvc;
using PokemonGO_Backend.Application.Services;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonCategoriesController : Controller
    {
        public GenericService<PokemonCategory,PokemonCategoryDTO> _service;

        public PokemonCategoriesController(GenericService<PokemonCategory,PokemonCategoryDTO> service)
        {
            _service = service;
        }

       
    }
}
