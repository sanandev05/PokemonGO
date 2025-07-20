namespace PokemonGO_Backend.Domain.Entities
{
    public class Gym : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }


        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }
    }
   
}
