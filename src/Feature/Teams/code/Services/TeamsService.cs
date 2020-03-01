using Hackathon.Foundation.DependencyInjection;
using System.Collections.Generic;
using Sitecore.Data.Items;
using Glass.Mapper.Sc.Builders;
using Glass.Mapper.Sc.Web;
using System.Linq;
using Sitecore.Data;

namespace Hackathon.Feature.Teams.Services
{
    [Service(typeof(ITeamsService), Lifetime = Lifetime.Transient)]
    public class TeamsService : ITeamsService
    {
        private readonly IRequestContext _context;

        public TeamsService(IRequestContext context)
        {
            _context = context;
        }

        public IEnumerable<IBasicTeam> GetTeams(ID hackathon)
        {
            GetItemByItemBuilder builder = new GetItemByItemBuilder();
            Item hackathonItem = _context.SitecoreService.GetItem<Item>(hackathon.Guid);

            var teams = hackathonItem.Axes.GetDescendants().Where(t => t.Template.BaseTemplates.Any(b => b.ID == Hackathon.Feature.Teams.Constants.BasicTeam.TemplateId));

            foreach(var teamItem in teams)
            {
                var itemBuilder = builder.Item(teamItem);
                yield return _context.SitecoreService.GetItem<IBasicTeam>(itemBuilder);
            }
        }
    }
}