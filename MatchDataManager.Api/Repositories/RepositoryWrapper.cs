using MatchDataManager.Api.Context;
using MatchDataManager.Api.Interfaces;

namespace MatchDataManager.Api.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _databaseContext;
        private ILocationsRepository _location;
        private ITeamsRepository _team;
        public ILocationsRepository Location
        {
            get
            {
                if (_location == null)
                {
                    _location = new LocationsRepository(_databaseContext);
                }
                return _location;
            }
        }
        public ITeamsRepository Team
        {
            get
            {
                if (_team == null)
                {
                    _team = new TeamsRepository(_databaseContext);
                }
                return _team;
            }
        }
        public RepositoryWrapper(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
