using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ILocationsRepository
    {
        void AddLocation(Location location);
        void DeleteLocation(Location location);
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<Location> GetLocationByIdAsync(Guid id);
        void UpdateLocation(Location location);
    }
}
