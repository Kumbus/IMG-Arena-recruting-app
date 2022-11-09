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
    internal sealed class TeamService : ITeamService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TeamService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<TeamDTO> AddAsync(TeamForCreationDTO teamForCreationDto, CancellationToken cancellationToken = default)
        {
            var team = _mapper.Map<Team>(teamForCreationDto);
            _repositoryManager.TeamsRepository.AddTeam(team);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            var createdTeam = _mapper.Map<TeamDTO>(team);
            return createdTeam;
        }

        public async Task DeleteAsync(Guid teamId, CancellationToken cancellationToken = default)
        {
            var team = await _repositoryManager.TeamsRepository.GetTeamByIdAsync(teamId, cancellationToken);
            if (team is null)
            {
                //throw new TeamNotFoundException(teamId);
            }
            _repositoryManager.TeamsRepository.DeleteTeam(team);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync(CancellationToken cancellationToken = default)
        {
            var teams = await _repositoryManager.TeamsRepository.GetAllTeamsAsync(cancellationToken);
            var teamsDTO = _mapper.Map<IEnumerable<TeamDTO>>(teams);

            return teamsDTO;
        }

        public async Task<TeamDTO> GetTeamByIdAsync(Guid teamId, CancellationToken cancellationToken = default)
        {
            var team = await _repositoryManager.TeamsRepository.GetTeamByIdAsync(teamId, cancellationToken);

            if (team is null)
            {
                //throw new TeamNotFoundException(teamId);
            }

            var teamDTO = _mapper.Map<TeamDTO>(team);
            return teamDTO;
        }

        public async Task UpdateAsync(Guid teamId, TeamForUpdateDTO teamForUpdateDto, CancellationToken cancellationToken = default)
        {
            var team = await _repositoryManager.TeamsRepository.GetTeamByIdAsync(teamId, cancellationToken);
            if (team is null)
            {
                //throw new TeamNotFoundException(teamId);
            }
            team.Name = teamForUpdateDto.Name;
            team.CoachName = teamForUpdateDto.CoachName;

            _repositoryManager.TeamsRepository.UpdateTeam(team);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
