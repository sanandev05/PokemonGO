using Microsoft.EntityFrameworkCore;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.Persistance.DBContext
{
    public class PokemonGoDbContext : DbContext
    {
        public PokemonGoDbContext(DbContextOptions<PokemonGoDbContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PokemonAbility> PokemonAbilities { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<LogData> LogDatas { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Badge> Badges { get; set; }
    }
}
