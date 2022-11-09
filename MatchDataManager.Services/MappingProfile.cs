using AutoMapper;
using MatchDataManager.Domain.Entities;
using MatchDataManager.Services.DTO;

namespace MatchDataManager.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationDTO>();
            CreateMap<LocationForCreationDTO, Location>();
            CreateMap<LocationForUpdateDTO, Location>();
            CreateMap<Team, TeamDTO>();
            CreateMap<TeamForCreationDTO, Team>();
            CreateMap<TeamForUpdateDTO, Team>();
        }
    }
}
