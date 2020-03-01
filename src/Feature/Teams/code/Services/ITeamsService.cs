using Sitecore.Data;
using System.Collections.Generic;

namespace Hackathon.Feature.Teams.Services
{
    public interface ITeamsService
    {
        IEnumerable<IBasicTeam> GetTeams(ID hackathon);
    }
}
