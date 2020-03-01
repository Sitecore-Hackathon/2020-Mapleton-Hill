using Hackathon.Foundation.DataAccess.Models;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Teams.Models
{
    public class BasicTeam : GlassBase, IBasicTeam
    {
        public string Name { get; set; }

        public IEnumerable<Guid> Members => throw new NotImplementedException();
    }
}