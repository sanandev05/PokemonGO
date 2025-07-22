namespace PokemonGO_Backend.Domain.Entities
{
    public class PokemonAbility : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Damage { get; set; }
        public decimal Accuracy { get; set; }

        public ICollection<Pokemon>? Pokemons { get; set; }
    }
}
