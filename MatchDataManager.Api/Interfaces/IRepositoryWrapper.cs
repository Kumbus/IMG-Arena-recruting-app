namespace MatchDataManager.Api.Interfaces
{
    public interface IRepositoryWrapper
    {
        ILocationsRepository Location { get; }
        ITeamsRepository Team { get; }

        Task SaveAsync();
    }
}
