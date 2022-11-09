
using MatchDataManager.Domain.Entities;
using MatchDataManager.Domain.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Infrastructure.Repositories;

public class LocationsRepository : RepositoryBase<Location>, ILocationsRepository 
{    
    public LocationsRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }

    public void AddLocation(Location location)
    {
        Add(location);
    }

    public void DeleteLocation(Location location)
    {
        Delete(location);
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken = default)
    {
        return await FindAll().ToListAsync(cancellationToken);
    }

    public async Task<Location> GetLocationByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(l => l.Id.Equals(id)).FirstOrDefaultAsync(cancellationToken);
    }

    public void UpdateLocation(Location location)
    {
        Update(location);
    }
}