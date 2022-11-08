using MatchDataManager.Api.Context;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : ITeamsRepository
{


    private readonly DatabaseContext _dbContext;

    public TeamsRepository(DatabaseContext databaseContext)
    {
        _dbContext = databaseContext;
    }

    public void AddTeam(Team team)
    {
        team.Id = Guid.NewGuid();
        _dbContext.Teams.Add(team);
        _dbContext.SaveChanges();
    }

    public void DeleteTeam(Guid teamId)
    {
        var team = _dbContext.Teams.FirstOrDefault(x => x.Id == teamId);
        _dbContext.Teams.Remove(team);
        _dbContext.SaveChanges();
     
    }

    public IEnumerable<Team> GetAllTeams()
    {
        return _dbContext.Teams.ToList();
    }

    public Team GetTeamById(Guid id)
    {
        return _dbContext.Teams.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateTeam(Team team)
    {
        var existingTeam = _dbContext.Teams.FirstOrDefault(x => x.Id == team.Id);
        if (existingTeam is null || team is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }

        existingTeam.CoachName = team.CoachName;
        existingTeam.Name = team.Name;

        _dbContext.SaveChanges();
    }
}