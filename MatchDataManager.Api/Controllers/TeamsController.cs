using AutoMapper;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Models.DTO;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;
    public TeamsController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }
    [HttpPost]
    public async Task<IActionResult> AddTeam(TeamForCreationDTO team)
    {
        if (ModelState.IsValid)
        {
            var teams = await _repositoryWrapper.Team.GetAllTeamsAsync();
            if (teams.Any(t => t.Name == team.Name))
                return BadRequest(new { message = "Team with this name already exists." });

            var mappedTeam = _mapper.Map<Team>(team);
            _repositoryWrapper.Team.AddTeam(mappedTeam);
            await _repositoryWrapper.SaveAsync();
            var createdTeam = _mapper.Map<TeamDTO>(mappedTeam);

            return CreatedAtAction(nameof(GetById), new { id = createdTeam.Id }, team);
        }

        return BadRequest(ModelState);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTeam(Guid teamId)
    {
        var team = await _repositoryWrapper.Team.GetTeamByIdAsync(teamId);
        if (team is not null)
        {
            _repositoryWrapper.Team.DeleteTeam(team);
            await _repositoryWrapper.SaveAsync();
            return Ok(new { message = "Team has been removed" });
        }

        return BadRequest(new { message = "Team with this id doesn't exists" });
    }

    [HttpGet]
    public  async Task<IActionResult> Get()
    {
        var teams = await _repositoryWrapper.Team.GetAllTeamsAsync();
        var teamsResult = _mapper.Map<IEnumerable<TeamDTO>>(teams);
        return Ok(teamsResult);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var team = await _repositoryWrapper.Team.GetTeamByIdAsync(id);
        if (team is null)
        {
            return NotFound();
        }

        var teamResult = _mapper.Map<TeamDTO>(team);
        return Ok(teamResult);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTeam(Guid id, TeamForUpdateDTO team)
    {
        
        if (ModelState.IsValid)
        {
            var existingTeam = await _repositoryWrapper.Team.GetTeamByIdAsync(id);
            if(existingTeam is null)
            {
                return NotFound();
            }
            else
            {
                var teams = await _repositoryWrapper.Team.GetAllTeamsAsync();
                if (teams.Any(t => t.Name == team.Name && t.Id != existingTeam.Id))
                    return BadRequest(new { message = "Team with this name already exists." });

                _mapper.Map(team, existingTeam);
                _repositoryWrapper.Team.UpdateTeam(existingTeam);
                await _repositoryWrapper.SaveAsync();
            }

            return Ok(team);
        }

        return BadRequest(ModelState);
    }
}