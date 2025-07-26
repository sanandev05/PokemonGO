namespace PokemonGO_Backend.Contract.DTOs
{
    public record PokemonCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
