using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Hackathon.Foundation.DependencyInjection.Extensions;
using Sitecore.Data;
using System;

namespace Hackathon.Foundation.DataAccess.Factories
{
    public static class GlassMapperFactory
    {
        public static ISitecoreService BuildSitecoreService(Database database)
        {
            return new SitecoreService(database);
        }

        public static ISitecoreService BuildSitecoreContextService()
        {
            var sitecoreServiceThunk = ServiceCollectionExtensions.Get<Func<Database, ISitecoreService>>();
            return sitecoreServiceThunk(Sitecore.Context.Database);
        }

        public static IRequestContext BuildRequestContext()
        {
            return new RequestContext(ServiceCollectionExtensions.Get<ISitecoreService>());
        }

        public static IGlassHtml BuildGlassHtml()
        {
            return new GlassHtml(ServiceCollectionExtensions.Get<ISitecoreService>());
        }

        public static IMvcContext BuildMvcContext()
        {
            return new MvcContext(ServiceCollectionExtensions.Get<ISitecoreService>(), ServiceCollectionExtensions.Get<IGlassHtml>());
        }
    }
}