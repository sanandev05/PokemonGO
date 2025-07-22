using PokemonGO_Backend.Contract.DTOs;

namespace PokemonGO_Backend.Contract.Services
{
    public interface IPokemonService
    {
        Task<PokemonDTO> AddAsync(PokemonDTO dto);
        Task<PokemonDTO> UpdateAsync(PokemonDTO dto);
        Task DeleteAsync(int id);
        Task<PokemonDTO> GetByIdAsync(int id);
        Task<IEnumerable<PokemonDTO>> GetAllAsync();
    }
}
