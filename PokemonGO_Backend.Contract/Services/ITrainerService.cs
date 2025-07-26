using PokemonGO_Backend.Contract.DTOs;

namespace PokemonGO_Backend.Contract.Services
{
    public interface ITrainerService
    {
        Task<List<TrainerDTO>> GetAll();
        Task<TrainerDTO> GetById(int id);
        Task<TrainerDTO> AddAsync(TrainerDTO dto);
        Task<TrainerDTO> UpdateAsync(int id, TrainerDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
