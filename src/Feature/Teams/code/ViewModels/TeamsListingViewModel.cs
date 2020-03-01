using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Teams.ViewModels
{
    public class TeamsListingViewModel
    {
        public IEnumerable<IBasicTeam> Teams { get; set; }
        public string TeamsHeader { get; set; }
    }
}