using Sitecore.Sites;

namespace Hackathon.Foundation.Dictionary.Repositories
{
    using Hackathon.Foundation.Dictionary.Models;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using System.Configuration;
    using System.Linq;

    public class DictionaryRepository : IDictionaryRepository
    {
        public Dictionary Get(SiteContext context)
        {
            return new Dictionary()
            {
                Root = GetDictionaryRoot(context, Settings.LocalDomainDictionaryTemplateId),
                Site = context
            };
        }

        private Item GetDictionaryRoot(SiteContext site, ID templateId)
        {
            Item siteRootItem = Sitecore.Context.Database.GetItem(site.RootPath);

            Item dictionaryRoot = siteRootItem.Axes.GetDescendants().Where(i => i.TemplateID.Equals(templateId)).SingleOrDefault<Item>();

            return dictionaryRoot;
        }

        private Item GetDictionaryRoot(SiteContext site)
        {
            var dictionaryPath = site.Properties["dictionaryPath"];
            if (dictionaryPath == null)
            {
                throw new ConfigurationErrorsException("No dictionaryPath was specified on the <site> definition.");
            }
            var rootItem = site.Database.GetItem(dictionaryPath);
            if (rootItem == null)
            {
                throw new ConfigurationErrorsException("The root item specified in the dictionaryPath on the <site> definition was not found.");
            }
            return rootItem;
        }

        public static class Settings
        {
            public static ID LocalDomainDictionaryTemplateId => new ID(Sitecore.Configuration.Settings.GetSetting("Hackathon.Foundation.Dictionary.LocalDomain.TemplateId"));
        }
    }
}