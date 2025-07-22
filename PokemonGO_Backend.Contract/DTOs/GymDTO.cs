namespace PokemonGO_Backend.Contract.DTOs
{
    public class GymDTO
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }


        public int LocationId { get; set; }

        public int TrainerId { get; set; }

        public List<int> PokemonIds { get; set; }
    }
}
