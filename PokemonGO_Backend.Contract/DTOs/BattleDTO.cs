using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Enums;

namespace PokemonGO_Backend.Contract.DTOs
{
    public class BattleDTO
    {
        public string Name { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public BattleResult Result { get; set; }

        public int LocationId { get; set; }

        public int Trainer1Id { get; set; }

        public int Trainer2Id { get; set; }

        public List<int> PokemonsUsedIds { get; set; }
    }
}
