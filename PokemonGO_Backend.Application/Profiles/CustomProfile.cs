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
                        .ForMember(dest => dest.AbilityIds, opt => opt.MapFrom(src => src.Abilities.Select(a => a.Id).ToList()))
                        .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(src => src.Categories.Select(c => c.Id).ToList()))
                        .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.TrainerId))
                        .ReverseMap()  // Enable reverse mapping (DTO -> Entity)
                        .ForMember(dest => dest.Abilities, opt => opt.Ignore())  // Ignore navigation properties on reverse map
                        .ForMember(dest => dest.Categories, opt => opt.Ignore())
                        .ForMember(dest => dest.Trainer, opt => opt.Ignore());
            CreateMap<PokemonAbility, PokemonAbilityDTO>().ReverseMap();
            CreateMap<Tournament, TournamentDTO>().ReverseMap();
            CreateMap<Trainer, TrainerDTO>().ReverseMap();
        }
    }
}
