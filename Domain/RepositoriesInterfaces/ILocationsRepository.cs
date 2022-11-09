using MatchDataManager.Domain.Entities;

namespace MatchDataManager.Domain.RepositoriesInterfaces
{
    public interface ILocationsRepository
    {
        void AddLocation(Location location);
        void DeleteLocation(Location location);
        Task<IEnumerable<Location>> GetAllLocationsAsync(CancellationToken cancellationToken = default);
        Task<Location> GetLocationByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void UpdateLocation(Location location);
    }
}
