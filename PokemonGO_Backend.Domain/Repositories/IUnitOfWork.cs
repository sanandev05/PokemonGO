namespace PokemonGO_Backend.Domain.Repositories
{
    public interface IUnitOfWork 
    {
        Task<int> SaveChangesAsync();
    }
}
