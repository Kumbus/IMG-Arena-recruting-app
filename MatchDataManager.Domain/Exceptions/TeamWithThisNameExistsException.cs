using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.Domain.Exceptions
{
    public sealed class TeamWithThisNameExistsException : BadRequestException
    {
        public TeamWithThisNameExistsException(string name) : base($"Team with name: {name} already exists.")
        {
        }
    }
}
