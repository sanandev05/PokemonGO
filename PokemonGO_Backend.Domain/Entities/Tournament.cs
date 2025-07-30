namespace PokemonGO_Backend.Domain.Entities
{
    public class Tournament : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; } = null!;

        // Many-to-many relationship with Trainers
        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }

}
