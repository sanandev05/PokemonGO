using AutoMapper;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Repositories;

namespace PokemonGO_Backend.Application.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IGenericRepository<Trainer> _repository;
        private readonly IGenericRepository<Pokemon> _pokemonRepository;
        private readonly IGenericRepository<Badge> _badgeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainerService(IGenericRepository<Trainer> repository, IGenericRepository<Pokemon> pokemonRepository, IGenericRepository<Badge> badgeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _pokemonRepository = pokemonRepository;
            _badgeRepository = badgeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TrainerDTO> AddAsync(TrainerDTO dto)
        {
            var trainer = _mapper.Map<Trainer>(dto);
            trainer.Badges = new List<Badge>();
            if (dto.BadgeIds != null && dto.BadgeIds.Any())
            {
                foreach (var item in dto.BadgeIds)
                {
                    var badge = await _badgeRepository.GetByIdAsync(item);
                    if (badge != null)
                    {
                        trainer.Badges.Add(_mapper.Map<Badge>(badge));
                    }

                }
            }
            else trainer.Badges = null;

            trainer.Pokemons = new List<Pokemon>();
            if (dto.PokemonIds!=null && dto.PokemonIds.Any())
            {
                foreach (var item in dto.PokemonIds)
                {
                    var pokemon = _mapper.Map<Pokemon>(await _pokemonRepository.GetByIdAsync(item));
                    if (pokemon != null)
                    {
                        trainer.Pokemons.Add(pokemon);
                    }
                }
            }
            trainer.CurrentXP = 0; 
            trainer.MaxXP = 1000;
            Random random = new Random();
            await _repository.AddAsync(trainer);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TrainerDTO>(trainer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var trainer = await _repository.GetByIdAsync(id);
            if (trainer == null) return false;

            await _repository.UpdateAsync(trainer);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<TrainerDTO>> GetAll()
        {
            var trainers = await _repository.GetAllAsync(null,x=>x.Pokemons);
            return _mapper.Map<List<TrainerDTO>>(trainers);
        }

        public async Task<TrainerDTO> GetById(int id)
        {
            var trainer = await _repository.GetByIdAsync(id,x=>x.Pokemons);
            return _mapper.Map<TrainerDTO>(trainer);
        }

        public async Task<TrainerDTO> UpdateAsync(int id, TrainerDTO dto)
        {
            var trainer = await _repository.GetByIdAsync(id);
            if (trainer == null) return null;

            _mapper.Map(dto, trainer);

            if (dto.BadgeIds.Any())
            {
                trainer.Badges = new List<Badge>();
                foreach (var item in dto.BadgeIds)
                {
                    var badge = await _badgeRepository.GetByIdAsync(item);
                    if (badge != null)
                    {
                        trainer.Badges.Add(_mapper.Map<Badge>(badge));
                    }
                }
            }
            else trainer.Badges = null;

            if (dto.PokemonIds.Any())
            {
                trainer.Pokemons = new List<Pokemon>();
                foreach (var item in dto.PokemonIds)
                {
                    var pokemon = await _pokemonRepository.GetByIdAsync(item);
                    if (pokemon != null)
                    {
                        trainer.Pokemons.Add(_mapper.Map<Pokemon>(pokemon));
                    }
                }
            }
            else trainer.Pokemons = null;

            await _repository.UpdateAsync(trainer);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TrainerDTO>(trainer);
        }
    }
}
