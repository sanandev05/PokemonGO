using AutoMapper;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Repositories;

namespace PokemonGO_Backend.Application.Services
{
    public class GymService : IGymService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Gym> _repository;
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IGenericRepository<Pokemon> _pokemonRepository;
        private readonly IGenericRepository<Trainer> _trainerRepository;

        public GymService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Gym> repository, IGenericRepository<Location> locationRepository, IGenericRepository<Pokemon> pokemonRepository, IGenericRepository<Trainer> trainerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
            _locationRepository = locationRepository;
            _pokemonRepository = pokemonRepository;
            _trainerRepository = trainerRepository;
        }

        public async Task<GymDTO> AddAsync(GymDTO dto)
        {
            var gym = _mapper.Map<Gym>(dto);

           
            if (!dto.TrainerId.HasValue) dto.TrainerId = null;
            await _repository.AddAsync(_mapper.Map<Gym>(dto));
            await _unitOfWork.SaveChangesAsync();
            return dto;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GymDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GymDTO> UpdateAsync(int id, GymDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
