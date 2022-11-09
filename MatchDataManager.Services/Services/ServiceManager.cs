using AutoMapper;
using MatchDataManager.Domain.RepositoriesInterfaces;
using MatchDataManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Services.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ILocationService> _lazyLocationService;
        private readonly Lazy<ITeamService> _lazyTeamService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyLocationService = new Lazy<ILocationService>(() => new LocationService(repositoryManager, mapper));
            _lazyTeamService = new Lazy<ITeamService>(() => new TeamService(repositoryManager, mapper));
        }
        public ILocationService LocationService => _lazyLocationService.Value;
        public ITeamService TeamService => _lazyTeamService.Value;
    }
}
