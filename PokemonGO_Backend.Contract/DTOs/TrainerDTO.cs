using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.Contract.DTOs
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public decimal Gold { get; set; }


        public List<Pokemon> Pokemons { get; set; }
        public List<Badge> Badges { get; set; }
        //public List<TournamentResult> TournamentResults { get; set; }
    }
}
