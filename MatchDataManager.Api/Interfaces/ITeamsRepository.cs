using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ITeamsRepository
    {
        void AddTeam(Team team);
        void DeleteTeam(Team team);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByIdAsync(Guid id);
        void UpdateTeam(Team team);
    }
}
