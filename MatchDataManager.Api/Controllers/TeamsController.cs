using MatchDataManager.Services.DTO;
using MatchDataManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public TeamsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    [HttpPost]
    public async Task<IActionResult> AddTeam(TeamForCreationDTO team)
    {

        var teamDTO = await _serviceManager.TeamService.AddAsync(team);

        return CreatedAtAction(nameof(GetById), new { id = teamDTO.Id }, team);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTeam(Guid teamId, CancellationToken cancellationToken)
    {
        await _serviceManager.TeamService.DeleteAsync(teamId, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public  async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var teams = await _serviceManager.TeamService.GetAllTeamsAsync(cancellationToken);
        
        return Ok(teams);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var teamDTO = await _serviceManager.TeamService.GetTeamByIdAsync(id, cancellationToken);
        return Ok(teamDTO);

    }

    [HttpPut]
    public async Task<IActionResult> UpdateTeam(Guid id, TeamForUpdateDTO team, CancellationToken cancellationToken)
    {
        await _serviceManager.TeamService.UpdateAsync(id, team, cancellationToken);
        return NoContent();
    }
}