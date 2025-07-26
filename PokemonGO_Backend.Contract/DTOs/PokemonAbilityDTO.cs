namespace PokemonGO_Backend.Contract.DTOs
{
    public class PokemonAbilityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Damage { get; set; }
        public decimal Accuracy { get; set; }

        public List<int>? PokemonIds { get; set; }
    }
}
