using Hackathon.Feature.Navigation.Models;

namespace Hackathon.Feature.Teams.Services
{
    public interface INavigationService
    {
        HeaderModel GetHeader();
        FooterModel GetFooter();
    }
}
