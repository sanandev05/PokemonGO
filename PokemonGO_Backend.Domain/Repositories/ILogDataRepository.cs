using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.Domain.Repositories
{
    public interface ILogDataRepository : IGenericRepository<LogData>
    {
        public Task AddAsync(LogData logData);
    }
}
