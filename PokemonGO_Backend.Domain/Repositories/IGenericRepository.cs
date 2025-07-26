using PokemonGO_Backend.Domain.Entities;
using System.Linq.Expressions;

namespace PokemonGO_Backend.Domain.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
