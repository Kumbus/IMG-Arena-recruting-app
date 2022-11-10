using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Domain.RepositoriesInterfaces
{
    public interface ITeamsRepository
    {
        void AddTeam(Team team);
        void DeleteTeam(Team team);
        Task<IEnumerable<Team>> GetAllTeamsAsync(CancellationToken cancellationToken = default);
        Task<Team> GetTeamByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void UpdateTeam(Team team);
    }
}
