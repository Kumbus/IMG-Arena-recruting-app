using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamsRepository _teamsRepository;
    public TeamsController(ITeamsRepository teamsRepository)
    {
        _teamsRepository = teamsRepository;
    }
    [HttpPost]
    public IActionResult AddTeam(Team team)
    {
        if (ModelState.IsValid)
        {
            if (_teamsRepository.GetAllTeams().Any(t => t.Name == team.Name))
                return BadRequest(new { message = "Team with this name already exists." });

            _teamsRepository.AddTeam(team);
            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        return BadRequest(ModelState);
    }

    [HttpDelete]
    public IActionResult DeleteTeam(Guid teamId)
    {
        var team = _teamsRepository.GetAllTeams().FirstOrDefault(x => x.Id == teamId);
        if (team is not null)
        {
            _teamsRepository.DeleteTeam(teamId);
            return Ok(new { message = "Team has been removed" });
        }

        return BadRequest(new { message = "Team with this id doesn't exists" });
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_teamsRepository.GetAllTeams());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var team = _teamsRepository.GetTeamById(id);
        if (team is null)
        {
            return NotFound();
        }

        return Ok(team);
    }

    [HttpPut]
    public IActionResult UpdateTeam(Team team)
    {
        var existingTeam = _teamsRepository.GetTeamById(team.Id);
        if (ModelState.IsValid)
        {
            if (_teamsRepository.GetAllTeams().Any(t => t.Name == team.Name && t.Id != existingTeam.Id))
                return BadRequest(new { message = "Team with this name already exists." });

            _teamsRepository.UpdateTeam(team);
            return Ok(team);
        }

        return BadRequest(ModelState);
    }
}