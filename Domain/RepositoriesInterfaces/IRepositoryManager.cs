using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Domain.RepositoriesInterfaces
{
    public interface IRepositoryManager
    {
        ILocationsRepository LocationsRepository { get; }
        ITeamsRepository TeamsRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
