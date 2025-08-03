using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Repositories;
using PokemonGO_Backend.Persistance.DBContext;

namespace PokemonGO_Backend.Persistance.Repositories
{
    public class LogDataRepository : GenericRepository<LogData>, ILogDataRepository
    {
        public LogDataRepository(PokemonGoDbContext context) : base(context)
        {
        }

        public async Task AddAsync(LogData logData)
        {
            await _context.LogDatas.AddAsync(logData);
            await _context.SaveChangesAsync();
        }
    }
}
