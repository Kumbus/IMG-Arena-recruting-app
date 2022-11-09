using MatchDataManager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetAllLocationsAsync(CancellationToken cancellationToken = default);
        Task<LocationDTO> GetLocationByIdAsync(Guid locationId, CancellationToken cancellationToken = default);
        Task<LocationDTO> AddAsync(LocationForCreationDTO locationForCreationDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid locationId, LocationForUpdateDTO locationForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid locationId, CancellationToken cancellationToken = default);
    }
}
