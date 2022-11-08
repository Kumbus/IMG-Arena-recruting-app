using MatchDataManager.Api.Context;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly DatabaseContext _dbContext;
    
    public LocationsRepository(DatabaseContext databaseContext)
    {
        _dbContext = databaseContext;
    }

    public void AddLocation(Location location)
    {
        location.Id = Guid.NewGuid();
        _dbContext.Locations.Add(location);
        _dbContext.SaveChanges();
    }

    public void DeleteLocation(Guid locationId)
    {
        var location = _dbContext.Locations.FirstOrDefault(x => x.Id == locationId);
        _dbContext.Locations.Remove(location);
        _dbContext.SaveChanges();

    }

    public IEnumerable<Location> GetAllLocations()
    {
        return _dbContext.Locations;
    }

    public Location GetLocationById(Guid id)
    {
        return _dbContext.Locations.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateLocation(Location location)
    {
        var existingLocation = _dbContext.Locations.FirstOrDefault(x => x.Id == location.Id);
        if (existingLocation is null || location is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }

        existingLocation.City = location.City;
        existingLocation.Name = location.Name;

        _dbContext.SaveChanges();
    }
}