using Sitecore.ExperienceForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.FormExtensions.Models
{
    public class TeamMember
    {
        public IViewModel TeamName { get; set; }
        public IViewModel Email { get; set; }
        public IViewModel Twitter { get; set; }
        public IViewModel LinkedIn { get; set; }
        public IViewModel FirstName { get; set; }
        public IViewModel LastName { get; set; }
        public IViewModel City { get; set; }
        public IViewModel State { get; set; }
        public IViewModel Country { get; set; }
    }
}