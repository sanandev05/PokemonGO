using PokemonGO_Backend.Contract.DTOs;

namespace PokemonGO_Backend.Contract.Services
{
    public interface IGymService
    {
        Task<List<GymDTO>> GetAll();
        Task<GymDTO> GetById(int id);
        Task<GymDTO> AddAsync(GymDTO dto);
        Task<GymDTO> UpdateAsync(int id, GymDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
