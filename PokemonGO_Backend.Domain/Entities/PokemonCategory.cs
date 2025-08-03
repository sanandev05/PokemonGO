using PokemonGO_Backend.Domain.Enums;

namespace PokemonGO_Backend.Domain.Entities
{
    public class PokemonCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
