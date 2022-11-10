using MatchDataManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Domain.Exceptions
{
    public sealed class LocationNotFoundException : NotFoundException
    {
        public LocationNotFoundException(Guid locationId) : base($"Location with id: {locationId} doesn't exist.")
        {
        }
    }
}
