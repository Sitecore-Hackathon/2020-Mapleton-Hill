using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Hackathon.Foundation.DataAccess.Factories;
using Hackathon.Foundation.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data;
using Sitecore.DependencyInjection;
using System;

namespace Hackathon.Foundation.DataAccess.Infrastructure
{
    public class GlassMapperConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection services)
        {
            //For getting a SitecoreService for any database
            services.AddSingleton<Func<Database, ISitecoreService>>(_ => GlassMapperFactory.BuildSitecoreService);

            // For injecting into Controllers
            services.AddScoped(_ => GlassMapperFactory.BuildSitecoreContextService());
            services.AddScoped(_ => GlassMapperFactory.BuildRequestContext());
            services.AddScoped(_ => GlassMapperFactory.BuildGlassHtml());
            services.AddScoped(_ => GlassMapperFactory.BuildMvcContext());

            // For injecting into Configuration Factory types like pipelines processors
            services.AddSingleton<Func<ISitecoreService>>(_ => ServiceCollectionExtensions.Get<ISitecoreService>);
            services.AddSingleton<Func<IRequestContext>>(_ => ServiceCollectionExtensions.Get<IRequestContext>);
            services.AddSingleton<Func<IGlassHtml>>(_ => ServiceCollectionExtensions.Get<IGlassHtml>);
            services.AddSingleton<Func<IMvcContext>>(_ => ServiceCollectionExtensions.Get<IMvcContext>);
        }
    }
}