namespace PokemonGO_Backend.Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public decimal Gold { get; set; }


        public ICollection<Pokemon> Pokemons { get; set; }
        public ICollection<Badge> Badges { get; set; }
        //public ICollection<TournamentResult> TournamentResults { get; set; }
    }
}
