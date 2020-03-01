using Glass.Mapper.Sc.Web.Mvc;
using Hackathon.Feature.Teams.Services;
using Hackathon.Feature.Teams.ViewModels;
using Sitecore.Mvc.Controllers;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Hackathon.Feature.Teams.Controllers
{
    public class TeamsController : SitecoreController
    {
        private readonly IMvcContext _context;
        private readonly ITeamsService _teamsService;

        public TeamsController(IMvcContext context, ITeamsService teamsService)
        {
            _context = context;
            _teamsService = teamsService;
        }

        public ActionResult Listing()
        {
            var hackathonItem = GetDataSourceItem();
            if(hackathonItem == null)
            {
                return new EmptyResult();
            }

            TeamsListingViewModel viewModel = new TeamsListingViewModel()
            {
                Teams = _teamsService.GetTeams(hackathonItem.ID),
                TeamsHeader = "Hackathon Teams"
            };

            return View(viewModel);
        }

        private Item GetDataSourceItem()
        {
            return _context.GetRenderingItem<Item>();
        }
    }
}