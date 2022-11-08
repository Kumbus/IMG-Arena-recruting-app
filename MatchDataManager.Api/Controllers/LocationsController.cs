using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{

    ILocationsRepository _locationsRepository;

    public LocationsController(ILocationsRepository locationsRepository)
    {
        _locationsRepository = locationsRepository;
    }

    [HttpPost]
    public IActionResult AddLocation(Location location)
    {
        if (ModelState.IsValid)
        {
            if (_locationsRepository.GetAllLocations().Any(l => l.Name == location.Name))
                return BadRequest(new { message = "Location with this name already exists." });

            _locationsRepository.AddLocation(location);
            return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
        }

        return BadRequest(ModelState);
        
    }

    [HttpDelete]
    public IActionResult DeleteLocation(Guid locationId)
    {
        var location = _locationsRepository.GetAllLocations().FirstOrDefault(x => x.Id == locationId);
        if (location is not null)
        {
            _locationsRepository.DeleteLocation(locationId);
            return Ok(new { message = "Location has been removed" });
        }

        return BadRequest(new { message = "Location with this id doesn't exists" });
  
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_locationsRepository.GetAllLocations());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var location = _locationsRepository.GetLocationById(id);
        if (location is null)
        {
            return NotFound();
        }

        return Ok(location);
    }

    [HttpPut]
    public IActionResult UpdateLocation(Location location)
    {

        if (ModelState.IsValid)
        {

            var existingLocation = _locationsRepository.GetLocationById(location.Id);
            if (_locationsRepository.GetAllLocations().Any(l => l.Name == location.Name && existingLocation.Id != l.Id))
                return BadRequest(new { message = "Location with this name already exists." });

            _locationsRepository.UpdateLocation(location);
            return Ok(location);
        }

        return BadRequest(ModelState);
    }
}