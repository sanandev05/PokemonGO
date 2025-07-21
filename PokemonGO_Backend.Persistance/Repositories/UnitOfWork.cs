using PokemonGO_Backend.Domain.Repositories;
using PokemonGO_Backend.Persistance.DBContext;

namespace PokemonGO_Backend.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PokemonGoDbContext _context;

        public UnitOfWork(PokemonGoDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
