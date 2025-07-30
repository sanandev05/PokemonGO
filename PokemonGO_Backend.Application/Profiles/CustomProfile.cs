using AutoMapper;
using PokemonGO_Backend.Contract.DTOs;
using PokemonGO_Backend.Domain.Entities;

namespace PokemonGO_Backend.Application.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<PokemonCategory, PokemonCategoryDTO>().ReverseMap();
            CreateMap<Badge, BadgeDTO>().ReverseMap();
            CreateMap<Battle, BattleDTO>().ReverseMap();
            CreateMap<Gym, GymDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<LogData, LogDataDTO>().ReverseMap();
            CreateMap<Pokemon, PokemonDTO>()
      .ForMember(dest => dest.TrainerIds,
                 opt => opt.MapFrom(src => src.Trainers.Select(t => t.Id)));


            CreateMap<PokemonDTO, Pokemon>()
                .ForMember(dest => dest.Abilities, opt => opt.Ignore())
                .ForMember(dest => dest.Trainers, opt => opt.Ignore());

            CreateMap<PokemonAbility, PokemonAbilityDTO>().ReverseMap();
            CreateMap<Tournament, TournamentDTO>().ReverseMap();
            CreateMap<Trainer, TrainerDTO>()
     .ForMember(dest => dest.PokemonIds,
                opt => opt.MapFrom(src => src.Pokemons.Select(p => p.Id)));

            CreateMap<TrainerDTO, Trainer>()
                .ForMember(dest => dest.Pokemons, opt => opt.Ignore());

        }
    }
}
