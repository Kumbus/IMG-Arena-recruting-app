using MatchDataManager.Api.Context;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Repositories;

public class LocationsRepository : RepositoryBase<Location>, ILocationsRepository 
{
    //private readonly DatabaseContext _dbContext;
    
    public LocationsRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }

    public void AddLocation(Location location)
    {
        Add(location);
        //location.Id = Guid.NewGuid();
        //_dbContext.Locations.Add(location);
        //_dbContext.SaveChanges();
    }

    public void DeleteLocation(Location location)
    {
        Delete(location);
        //var location = _dbContext.Locations.FirstOrDefault(x => x.Id == locationId);
        //_dbContext.Locations.Remove(location);
        //_dbContext.SaveChanges();

    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync()
    {
        return await FindAll().ToListAsync();
        //return _dbContext.Locations;
    }

    public async Task<Location> GetLocationByIdAsync(Guid id)
    {
        return await FindByCondition(l => l.Id.Equals(id)).FirstOrDefaultAsync();
        //return _dbContext.Locations.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateLocation(Location location)
    {

        Update(location);
        //var existingLocation = _dbContext.Locations.FirstOrDefault(x => x.Id == location.Id);
        //if (existingLocation is null || location is null)
        //{
        //    throw new ArgumentException("Location doesn't exist.", nameof(location));
        //}

        //existingLocation.City = location.City;
        //existingLocation.Name = location.Name;

        //_dbContext.SaveChanges();
    }
}