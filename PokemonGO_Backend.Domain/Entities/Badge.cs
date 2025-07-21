namespace PokemonGO_Backend.Domain.Entities
{
    public class Badge : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Level { get; set; }

        public ICollection<Trainer> Trainers { get; set; }
    }

}