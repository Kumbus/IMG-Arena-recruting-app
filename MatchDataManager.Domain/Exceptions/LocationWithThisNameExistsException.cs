using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MatchDataManager.Domain.Exceptions
{
    public sealed class LocationWithThisNameExistsException : BadRequestException
    {
        public LocationWithThisNameExistsException(string name) : base($"location with name: {name} already exists.")
        {
        }
    }
}
