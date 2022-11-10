using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Domain.Exceptions
{
    public sealed class TeamNotFoundException : NotFoundException
    {
        public TeamNotFoundException(Guid teamId) : base($"Team with id: {teamId} doesn't exist.")
        {
        }

    }
}
