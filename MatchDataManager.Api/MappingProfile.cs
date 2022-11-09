using AutoMapper;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Models.DTO;

namespace MatchDataManager.Api
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
