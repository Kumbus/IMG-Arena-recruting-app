using MatchDataManager.Domain.Entities;
using MatchDataManager.Domain.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Infrastructure.Repositories;

public class TeamsRepository : RepositoryBase<Team>, ITeamsRepository
{
    public TeamsRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public void AddTeam(Team team)
    {
        Add(team);
    }

    public void DeleteTeam(Team team)
    {
        Delete(team);
     
    }

    public async Task<IEnumerable<Team>> GetAllTeamsAsync(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<Team> GetTeamByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(l => l.Id.Equals(id)).FirstOrDefaultAsync(cancellationToken);
    }

    public void UpdateTeam(Team team)
    {
        Update(team);
    }
}