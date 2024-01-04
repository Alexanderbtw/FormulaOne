using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;

namespace FormulaOne.API.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                .ForMember(
                    dest => dest.Wins,
                    opt => opt.MapFrom(src => src.RaceWins)
                )
                .ForMember(
                    dest => dest.AchievementId,
                    opt => opt.MapFrom(src => src.Id)
                );

            CreateMap<Driver, GetDriverResponse>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + ' ' + src.LastName)
                )
                .ForMember(
                    dest => dest.DriverId,
                    opt => opt.MapFrom(src => src.Id)
                );
        }
    }
}
