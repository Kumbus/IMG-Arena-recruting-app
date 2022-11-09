using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Services.Interfaces
{
    public interface IServiceManager
    {
        ILocationService LocationService { get; }
        ITeamService TeamService { get; }
    }
}
