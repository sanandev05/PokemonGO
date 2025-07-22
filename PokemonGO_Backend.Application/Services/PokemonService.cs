using AutoMapper;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Contract.Services;
using PokemonGO_Backend.Domain.Entities;

public class PokemonService : IPokemonService
{
    private readonly IGenericService<PokemonAbility, PokemonAbilityDTO> _abilityService;
    private readonly IGenericService<PokemonCategory, PokemonCategoryDTO> _categoryService;
    private readonly IGenericService<Trainer, TrainerDTO> _trainerService;
    private readonly IGenericService<Pokemon, PokemonDTO> _pokemonService;
    private readonly IMapper _mapper;

    public PokemonService(
        IGenericService<PokemonAbility, PokemonAbilityDTO> abilityService,
        IGenericService<PokemonCategory, PokemonCategoryDTO> categoryService,
        IGenericService<Trainer, TrainerDTO> trainerService,
        IGenericService<Pokemon, PokemonDTO> pokemonService,
        IMapper mapper)
    {
        _abilityService = abilityService;
        _categoryService = categoryService;
        _trainerService = trainerService;
        _pokemonService = pokemonService;
        _mapper = mapper;
    }

    public async Task<PokemonDTO> AddAsync(PokemonDTO dto)
    {
        var pokemon = _mapper.Map<Pokemon>(dto);

        if (dto.AbilityIds != null && dto.AbilityIds.Any())
        {
            var abilities = new List<PokemonAbility>();
            foreach (var abilityId in dto.AbilityIds)
            {
                var ability = await _abilityService.GetByIdAsync(abilityId);
                if (ability != null)
                {
                    abilities.Add(_mapper.Map<PokemonAbility>(ability));
                }
            }
            pokemon.Abilities = abilities;
        }

        if (dto.CategoryIds != null && dto.CategoryIds.Any())
        {
            var categories = new List<PokemonCategory>();
            foreach (var categoryId in dto.CategoryIds)
            {
                var category = await _categoryService.GetByIdAsync(categoryId);
                if (category != null)
                {
                    categories.Add(_mapper.Map<PokemonCategory>(category));
                }
            }
            pokemon.Categories = categories;
        }

        if (dto.TrainerId.HasValue)
        {
            var trainerDto = await _trainerService.GetByIdAsync(dto.TrainerId.Value);
            if (trainerDto != null)
            {
                pokemon.Trainer = _mapper.Map<Trainer>(trainerDto);
                pokemon.TrainerId = dto.TrainerId;
            }
            else
            {
                pokemon.Trainer = null;
                pokemon.TrainerId = null;
            }
        }
        else
        {
            pokemon.Trainer = null;
            pokemon.TrainerId = null;
        }

        var createdPokemonDto = await _pokemonService.AddAsync(_mapper.Map<PokemonDTO>(pokemon));

        return createdPokemonDto;
    }

    public async Task<PokemonDTO> UpdateAsync(PokemonDTO dto)
    {
        var existing = await _pokemonService.GetByIdAsync(dto.Id);
        if (existing == null)
            return null;

        var pokemon = _mapper.Map<Pokemon>(dto);

        if (dto.AbilityIds != null && dto.AbilityIds.Any())
        {
            var abilities = new List<PokemonAbility>();
            foreach (var abilityId in dto.AbilityIds)
            {
                var ability = await _abilityService.GetByIdAsync(abilityId);
                if (ability != null)
                    abilities.Add(_mapper.Map<PokemonAbility>(ability));
            }
            pokemon.Abilities = abilities;
        }

        if (dto.CategoryIds != null && dto.CategoryIds.Any())
        {
            var categories = new List<PokemonCategory>();
            foreach (var categoryId in dto.CategoryIds)
            {
                var category = await _categoryService.GetByIdAsync(categoryId);
                if (category != null)
                    categories.Add(_mapper.Map<PokemonCategory>(category));
            }
            pokemon.Categories = categories;
        }

        if (dto.TrainerId.HasValue)
        {
            var trainerDto = await _trainerService.GetByIdAsync(dto.TrainerId.Value);
            if (trainerDto != null)
            {
                pokemon.Trainer = _mapper.Map<Trainer>(trainerDto);
                pokemon.TrainerId = dto.TrainerId;
            }
            else
            {
                pokemon.Trainer = null;
                pokemon.TrainerId = null;
            }
        }
        else
        {
            pokemon.Trainer = null;
            pokemon.TrainerId = null;
        }

        var updatedDto = await _pokemonService.UpdateAsync(_mapper.Map<PokemonDTO>(pokemon));
        return updatedDto;
    }

    public async Task DeleteAsync(int id)
    {
        await _pokemonService.DeleteAsync(id);
    }

    public async Task<PokemonDTO> GetByIdAsync(int id)
    {
        return await _pokemonService.GetByIdAsync(id);
    }

    public async Task<IEnumerable<PokemonDTO>> GetAllAsync()
    {
        return await _pokemonService.GetAllAsync();
    }
}