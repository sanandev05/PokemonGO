namespace PokemonGO_Backend.Domain.Entities
{
    public class Pokemon : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int XP { get; set; }
        public int Level { get; set; }
        public int MaxHP { get; set; }       
        public int CurrentHP { get; set; }   

        public ICollection<Trainer> Trainers { get; set; }

        public ICollection<PokemonAbility> Abilities { get; set; }
        public PokemonCategory Category{ get; set; }
        public int CategoryId { get; set; }
    }
   
}
