using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Feature.Teams.Services
{
    public interface ITeamsService
    {
        IEnumerable<IBasicTeam> GetTeams();
    }
}
