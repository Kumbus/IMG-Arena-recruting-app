using MatchDataManager.Domain.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Infrastructure.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ILocationsRepository> _lazyLocationRepository;
        private readonly Lazy<ITeamsRepository> _lazyTeamRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(DatabaseContext databasebContext)
        {
            _lazyLocationRepository = new Lazy<ILocationsRepository>(() => new LocationsRepository(databasebContext));
            _lazyTeamRepository = new Lazy<ITeamsRepository>(() => new TeamsRepository(databasebContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(databasebContext));
        }

        public ILocationsRepository LocationsRepository => _lazyLocationRepository.Value;

        public ITeamsRepository TeamsRepository => _lazyTeamRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
