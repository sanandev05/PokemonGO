namespace PokemonGO_Backend.Domain.Entities
{
    public class Tournament : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }

        public Location Location { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
    }
}
