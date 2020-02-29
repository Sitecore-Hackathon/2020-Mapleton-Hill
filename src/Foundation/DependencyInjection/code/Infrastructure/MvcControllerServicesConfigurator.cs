using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Hackathon.Foundation.DependencyInjection.Extensions;
using System.Web;

namespace Hackathon.Foundation.DependencyInjection.Infrastructure
{
    public class MvcControllerServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<HttpRequestBase>(p => new HttpRequestWrapper(HttpContext.Current.Request));

            serviceCollection.AddMvcControllers("Hackathon.Feature.*");
            serviceCollection.AddClassesWithServiceAttribute("Hackathon.Feature.*");
            serviceCollection.AddClassesWithServiceAttribute("Hackathon.Foundation.*");
        }
    }
}