using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ITeamsRepository
    {
        void AddTeam(Team team);
        void DeleteTeam(Guid teamId);
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(Guid id);
        void UpdateTeam(Team team);
    }
}
