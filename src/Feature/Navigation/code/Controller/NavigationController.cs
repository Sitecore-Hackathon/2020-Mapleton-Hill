using Glass.Mapper.Sc.Web;
using Hackathon.Feature.Navigation.Models;
using Hackathon.Feature.Teams.Services;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Feature.Navigation.Controller
{
    public class NavigationController : SitecoreController
    {
        private readonly IRequestContext _context;
        private readonly INavigationService _navService;

        public NavigationController(IRequestContext context, INavigationService navService)
        {
            _context = context;
            _navService = navService;
        }

        public ActionResult Header()
        {
            HeaderModel model = new NavigationService().GetHeader();

            return View( model);
        }

        public ActionResult Footer()
        {
            FooterModel model = new NavigationService().GetFooter();
            return View(model);
        }
    }
}