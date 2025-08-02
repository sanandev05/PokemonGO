using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.Contract.DTOs
{
    public class TournamentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }

        public int? LocationId { get; set; }
        public List<int>? TrainerIds { get; set; }
    }
}
