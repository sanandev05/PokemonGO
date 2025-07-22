using Microsoft.EntityFrameworkCore;
using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Repositories;
using PokemonGO_Backend.Persistance.DBContext;

namespace PokemonGO_Backend.Persistance.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly PokemonGoDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PokemonGoDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            return true;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet.AsQueryable().Where(x=>!x.IsDeleted));
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x=>x.Id==id&&!x.IsDeleted);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }
    }
}
