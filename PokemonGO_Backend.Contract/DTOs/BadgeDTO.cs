using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.Contract.DTOs
{
    public class BadgeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }

        public List<int> TrainerIds { get; set; }
    }
}
