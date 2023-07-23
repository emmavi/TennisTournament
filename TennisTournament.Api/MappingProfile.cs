using AutoMapper;
using TennisTournament.Api.DTOs;
using TennisTournament.Domain;
using TennisTournament.Domain.Gender;

namespace TennisTournament.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MalePlayerDTO, Player>()
                .ConstructUsing((src, res) =>
                {
                    return new Player(src.Name, PlayerGender.Male, src.Skill, src.Luck, new MaleStrengths(src.Power, src.Speed));
                });

            CreateMap<Player, MalePlayerDTO>()
                .ForMember(dest => dest.Power, act => act.MapFrom(src => ((MaleStrengths)src.GenderStrengths).Power))
                .ForMember(dest => dest.Speed, act => act.MapFrom(src => ((MaleStrengths)src.GenderStrengths).Speed));

            CreateMap<FemalePlayerDTO, Player>()
                .ConstructUsing((src, res) =>
                {
                    return new Player(src.Name, PlayerGender.Female, src.Skill, src.Luck, new FemaleStrengths(src.ReactionTime));
                });

            CreateMap<Player, FemalePlayerDTO>()
                .ForMember(dest => dest.ReactionTime, act => act.MapFrom(src => ((FemaleStrengths)src.GenderStrengths).ReactionTime));


            CreateMap<Tournament, TournamentDTO>()
                .ForMember(dest => dest.Gender, act => act.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Winner, act => act.MapFrom(src => src.Winner.Name));
        }
    }
}
