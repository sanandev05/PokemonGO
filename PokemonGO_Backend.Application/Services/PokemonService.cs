using AutoMapper;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;
using PokemonGO_Backend.Domain.Repositories;

public class PokemonService : IPokemonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Pokemon> _pokemonRepository;
    private readonly IGenericRepository<PokemonAbility> _abilityRepository;
    private readonly IGenericRepository<PokemonCategory> _categoryRepository;
    private readonly IGenericRepository<Trainer> _trainerRepository;
    private readonly IMapper _mapper;

    public PokemonService(
        IUnitOfWork unitOfWork,
        IGenericRepository<Pokemon> pokemonRepository,
        IGenericRepository<PokemonAbility> abilityRepository,
        IGenericRepository<PokemonCategory> categoryRepository,
        IGenericRepository<Trainer> trainerRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _pokemonRepository = pokemonRepository;
        _abilityRepository = abilityRepository;
        _categoryRepository = categoryRepository;
        _trainerRepository = trainerRepository;
        _mapper = mapper;
    }

    public async Task<PokemonDTO> AddAsync(PokemonDTO dto)
    {
         var pokemon = _mapper.Map<Pokemon>(dto);

        pokemon.Abilities = new List<PokemonAbility>();
        if (dto.AbilityIds != null && dto.AbilityIds.Any())
        {
            foreach (var abilityId in dto.AbilityIds)
            {
                var ability = await _abilityRepository.GetByIdAsync(abilityId);
                if (ability != null)
                    pokemon.Abilities.Add(ability);
            }
        }

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category != null)
            pokemon.Category = category;

        if (dto.TrainerIds !=null && dto.TrainerIds.Any())
        {
            var trainers = (await _trainerRepository.GetAllAsync()).Where(x=>dto.TrainerIds.Contains(x.Id)).ToList();

            pokemon.Trainers = trainers;
        }
        else
        {
            dto.TrainerIds = null;
            pokemon.Trainers = null;
        }
        Random random = new Random();
        pokemon.MaxHP= 100;
        pokemon.CurrentHP = random.Next(35,100);
        await _pokemonRepository.AddAsync(pokemon);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<PokemonDTO>(pokemon);
    }

    public async Task<PokemonDTO> UpdateAsync(PokemonDTO dto)
    {
        var pokemon = await _pokemonRepository.GetByIdAsync(dto.Id, p => p.Abilities, p => p.Category);
        if (pokemon == null)
            return null;

        _mapper.Map(dto, pokemon);

        pokemon.Abilities.Clear();
        if (dto.AbilityIds != null && dto.AbilityIds.Any())
        {
            foreach (var abilityId in dto.AbilityIds)
            {
                var ability = await _abilityRepository.GetByIdAsync(abilityId);
                if (ability != null)
                    pokemon.Abilities.Add(ability);
            }
        }

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category != null)
            pokemon.Category = category;

        if (dto.TrainerIds != null && dto.TrainerIds.Any())
        {
            var trainers = (await _trainerRepository.GetAllAsync()).Where(x => dto.TrainerIds.Contains(x.Id)).ToList();
            pokemon.Trainers = trainers;
        }
        else
        {
            pokemon.Trainers = null;
        }

        await _pokemonRepository.UpdateAsync(pokemon);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<PokemonDTO>(pokemon);
    }

    public async Task DeleteAsync(int id)
    {
        var pokemon = await _pokemonRepository.GetByIdAsync(id);
        if (pokemon != null)
        {
            await _pokemonRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<PokemonDTO> GetByIdAsync(int id)
    {
        var pokemon = await _pokemonRepository.GetByIdAsync(id, p => p.Abilities, p => p.Category);
        return _mapper.Map<PokemonDTO>(pokemon);
    }

    public async Task<IEnumerable<PokemonDTO>> GetAllAsync()
    {
        var pokemons = await _pokemonRepository.GetAllAsync(null, p => p.Abilities, p => p.Category);
        return _mapper.Map<IEnumerable<PokemonDTO>>(pokemons);
    }
}
