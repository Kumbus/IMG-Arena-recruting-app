using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ILocationsRepository
    {
        void AddLocation(Location location);
        void DeleteLocation(Guid locationId);
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(Guid id);
        void UpdateLocation(Location location);
    }
}
