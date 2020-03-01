using Hackathon.Feature.Navigation.Models;
using Hackathon.Foundation.DependencyInjection;
using System.Collections.Generic;

namespace Hackathon.Feature.Teams.Services
{
    [Service(typeof(INavigationService), Lifetime = Lifetime.Transient)]
    public class NavigationService : INavigationService
    {
        
        public NavigationService()
        {

        }

        public HeaderModel GetHeader()
        {
             var mockHeader = new HeaderModel()
            {
                Image = new Glass.Mapper.Sc.Fields.Image()
                {
                     Src = "http://www.sitecorehackathon.org/wp-content/uploads/2017/01/Sitecore-Hackathon-logo-small-own-it.png", 
                     Alt = "Sitecore Hackathon"
                },
                Menu = new MenuModel()
                { 
                     Items = new List<MenuModel>() {
                         new MenuModel() { 
                              Link = new Glass.Mapper.Sc.Fields.Link() { 
                                Text = "Home", 
                                Url = "#"
                              }
                         },
                          new MenuModel() {
                              Link = new Glass.Mapper.Sc.Fields.Link() {
                                Text = "Newsletter",
                                Url = "#"
                              }
                         },
                            new MenuModel() {
                              Link = new Glass.Mapper.Sc.Fields.Link() {
                                Text = "Hackathons",
                                Url = "#" 
                              },
                                 Items = new List<MenuModel>() {
                                     new MenuModel() {
                                          Link = new Glass.Mapper.Sc.Fields.Link() {
                                            Text = "2020",
                                            Url = "#"
                                          }
                                     },
                                      new MenuModel() {
                                          Link = new Glass.Mapper.Sc.Fields.Link() {
                                            Text = "2019",
                                            Url = "#"
                                          }
                                     }
                                 }
                              }
                         }
                     }
            };

            return mockHeader;
        }

        public FooterModel GetFooter()
        {
            var mockF = new FooterModel()
            {
                Title  = "Sitecore Hackathon",
                Menu = new MenuModel()
                {
                    Items = new List<MenuModel>() {
                         new MenuModel() {
                              Link = new Glass.Mapper.Sc.Fields.Link() {
                                Text = "Home",
                                Url = "#"
                              }
                         },
                          new MenuModel() {
                              Link = new Glass.Mapper.Sc.Fields.Link() {
                                Text = "Newsletter",
                                Url = "#"
                              }
                         }
                     }
                }
            };
            return mockF;
        }
    }
}