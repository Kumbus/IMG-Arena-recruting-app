using MatchDataManager.Api.Context;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Repositories;

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

    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<Team> GetTeamByIdAsync(Guid id)
    {
        return await FindByCondition(l => l.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public void UpdateTeam(Team team)
    {
        Update(team);
    }
}