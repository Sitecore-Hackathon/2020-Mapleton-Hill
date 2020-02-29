using Sitecore.ExperienceForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.FormExtensions.Models
{
    public class TeamMember
    {
        public string TeamName { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}