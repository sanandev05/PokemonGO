using AutoMapper;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Repositories;

namespace PokemonGO_Backend.Application.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
        where TEntity : BaseEntity, new()
        where TDto : class
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected IGenericRepository<TEntity> _repository { get; set; }
        private readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity.Id);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.UpdateAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
    }
}
