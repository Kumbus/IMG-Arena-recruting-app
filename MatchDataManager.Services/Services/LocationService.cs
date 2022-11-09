using AutoMapper;
using MatchDataManager.Domain.Entities;
using MatchDataManager.Domain.RepositoriesInterfaces;
using MatchDataManager.Services.DTO;
using MatchDataManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Services.Services
{
    internal sealed class LocationService : ILocationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public LocationService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<LocationDTO> AddAsync(LocationForCreationDTO locationForCreationDto, CancellationToken cancellationToken = default)
        {
            var location = _mapper.Map<Location>(locationForCreationDto);
            _repositoryManager.LocationsRepository.AddLocation(location);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            var createdTeam = _mapper.Map<LocationDTO>(location);
            return createdTeam;
        }

        public async Task DeleteAsync(Guid locationId, CancellationToken cancellationToken = default)
        {
            var location = await _repositoryManager.LocationsRepository.GetLocationByIdAsync(locationId, cancellationToken);
            if (location is null)
            {
                //throw new LocationNotFoundException(locationId);
            }
            _repositoryManager.LocationsRepository.DeleteLocation(location);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken cancellationToken = default)
        {
            var locations = await _repositoryManager.LocationsRepository.GetAllLocationsAsync(cancellationToken);
            var locationsDTO = _mapper.Map<IEnumerable<LocationDTO>>(locations);
            

            return locationsDTO;
        }

        public async Task<LocationDTO> GetLocationByIdAsync(Guid locationId, CancellationToken cancellationToken = default)
        {
            var location = await _repositoryManager.LocationsRepository.GetLocationByIdAsync(locationId, cancellationToken);

            if(location is null)
            {
                //throw new LocationNotFoundException(locationId);
            }

            var locationDTO = _mapper.Map<LocationDTO>(location);
            return locationDTO;
        }

        public async Task UpdateAsync(Guid locationId, LocationForUpdateDTO locationForUpdateDto, CancellationToken cancellationToken = default)
        {
            var location = await _repositoryManager.LocationsRepository.GetLocationByIdAsync(locationId, cancellationToken);
            if (location is null)
            {
                //throw new LocationNotFoundException(locationId);
            }
            location.Name = locationForUpdateDto.Name;
            location.City = locationForUpdateDto.City;

            _repositoryManager.LocationsRepository.UpdateLocation(location);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
