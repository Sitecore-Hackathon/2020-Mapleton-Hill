using System;

namespace Hackathon.Feature.FormExtensions.Models
{
    public class TeamMember
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }
}