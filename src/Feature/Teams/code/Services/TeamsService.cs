using Hackathon.Feature.Teams.Models;
using Hackathon.Foundation.DependencyInjection;
using System.Collections.Generic;

namespace Hackathon.Feature.Teams.Services
{
    [Service(typeof(ITeamsService), Lifetime = Lifetime.Transient)]
    public class TeamsService : ITeamsService
    {
        
        public TeamsService()
        {

        }

        public IEnumerable<IBasicTeam> GetTeams()
        {
            var mockTeams = new List<BasicTeam>()
            {
                new BasicTeam()
                {
                    Name = "Mapleton Hill"
                },
                new BasicTeam()
                {
                    Name = "Sitecore Crew"
                },
                new BasicTeam()
                {
                    Name = "No Name #1"
                }
            };

            return mockTeams;
        }
    }
}