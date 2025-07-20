namespace PokemonGO_Backend.Domain.Entities
{
    public class PokemonAbility : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
        public decimal Power { get; set; }
        public decimal Accuracy { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
