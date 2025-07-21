using PokemonGO_Backend.Domain.Enums;

namespace PokemonGO_Backend.Domain.Entities
{
    public class Battle : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartedAt { get; set; }       
        public DateTime? EndedAt { get; set; }    
        public BattleResult Result { get; set; }      

        public int LocationId { get; set; }
        public Location BattleLocation { get; set; }

        public int Trainer1Id { get; set; }
        public Trainer Trainer1 { get; set; }

        public int Trainer2Id { get; set; }
        public Trainer Trainer2 { get; set; }

        public ICollection<Pokemon> PokemonsUsed { get; set; } 
    }
    
}
