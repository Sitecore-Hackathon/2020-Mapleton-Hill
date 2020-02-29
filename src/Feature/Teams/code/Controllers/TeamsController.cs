using Glass.Mapper.Sc.Web;
using Hackathon.Feature.Teams.Services;
using Hackathon.Feature.Teams.ViewModels;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace Hackathon.Feature.Teams.Controllers
{
    public class TeamsController : SitecoreController
    {
        private readonly IRequestContext _context;
        private readonly ITeamsService _teamsService;

        public TeamsController(IRequestContext context, ITeamsService teamsService)
        {
            _context = context;
            _teamsService = teamsService;
        }

        public ActionResult Listing()
        {
            TeamsListingViewModel viewModel = new TeamsListingViewModel()
            {
                Teams = _teamsService.GetTeams(),
                TeamsHeader = "Hackathon Teams"
            };

            return View(viewModel);
        }
    }
}