using MatchDataManager.Services.DTO;
using MatchDataManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public LocationsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost]
    public async Task<ActionResult<LocationDTO>> AddLocation(LocationForCreationDTO location)
    {
        var locationDTO = await _serviceManager.LocationService.AddAsync(location);

        return CreatedAtAction(nameof(GetById), new { id = locationDTO.Id }, location);      
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLocation(Guid locationId, CancellationToken cancellationToken)
    {

        await _serviceManager.LocationService.DeleteAsync(locationId, cancellationToken);
        return NoContent();
  
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationDTO>>> Get(CancellationToken cancellationToken)
    {
        var locations = await _serviceManager.LocationService.GetAllLocationsAsync(cancellationToken);
        return Ok(locations);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LocationDTO>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var locationDTO = await _serviceManager.LocationService.GetLocationByIdAsync(id, cancellationToken);
        return Ok(locationDTO);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(Guid id, LocationForUpdateDTO location, CancellationToken cancellationToken)
    {
        await _serviceManager.LocationService.UpdateAsync(id, location, cancellationToken);
        return NoContent();

    }
}