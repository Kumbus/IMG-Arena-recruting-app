using AutoMapper;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Models.DTO;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{

    //ILocationsRepository _locationsRepository;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public LocationsController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddLocation(LocationForCreationDTO location)
    {
        if (ModelState.IsValid)
        {
            var locations = await _repositoryWrapper.Location.GetAllLocationsAsync();
            if (locations.Any(l => l.Name == location.Name))
                return BadRequest(new { message = "Location with this name already exists." });

            var mappedLocation = _mapper.Map<Location>(location);
            _repositoryWrapper.Location.AddLocation(mappedLocation);
            await _repositoryWrapper.SaveAsync();

            var createdLocation = _mapper.Map<LocationDTO>(mappedLocation);

            return CreatedAtAction(nameof(GetById), new { id = createdLocation.Id }, location);
        }

        return BadRequest(ModelState);
        
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLocation(Guid locationId)
    {
        var location = await _repositoryWrapper.Location.GetLocationByIdAsync(locationId);
        if (location is not null)
        {
            _repositoryWrapper.Location.DeleteLocation(location);
            await _repositoryWrapper.SaveAsync();
            return NoContent();
        }

        return BadRequest(new { message = "Location with this id doesn't exists" });
  
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var locations = await _repositoryWrapper.Location.GetAllLocationsAsync();
        var locationsResult = _mapper.Map<IEnumerable<LocationDTO>>(locations);
        return Ok(locationsResult);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var location = await _repositoryWrapper.Location.GetLocationByIdAsync(id);
        if (location is null)
        {
            return NotFound();
        }

        var locationResult = _mapper.Map<LocationDTO>(location);
        return Ok(locationResult);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(Guid id, LocationForUpdateDTO location)
    {

        if (ModelState.IsValid)
        {

            var existingLocation = await _repositoryWrapper.Location.GetLocationByIdAsync(id);
            if (existingLocation is null)
            {
                return NotFound();
            }
            else 
            {
               var locations = await _repositoryWrapper.Location.GetAllLocationsAsync();
                if (locations.Any(l => l.Name == location.Name && id != l.Id))
                    return BadRequest(new { message = "Location with this name already exists." });
            } 

            _mapper.Map(location, existingLocation);
            _repositoryWrapper.Location.UpdateLocation(existingLocation);
            await _repositoryWrapper.SaveAsync();

            return Ok(location);
        }

        return BadRequest(ModelState);
    }
}