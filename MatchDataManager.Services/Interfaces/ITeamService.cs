using MatchDataManager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> GetAllTeamsAsync(CancellationToken cancellationToken = default);
        Task<TeamDTO> GetTeamByIdAsync(Guid teamId, CancellationToken cancellationToken = default);
        Task<TeamDTO> AddAsync(TeamForCreationDTO teamForCreationDto, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid teamId, TeamForUpdateDTO teamForUpdateDto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid teamId, CancellationToken cancellationToken = default);
    }
}
