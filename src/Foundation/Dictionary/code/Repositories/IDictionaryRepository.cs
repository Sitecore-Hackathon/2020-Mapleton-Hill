namespace Hackathon.Foundation.Dictionary.Repositories
{
    using Hackathon.Foundation.Dictionary.Models;
    using Sitecore.Sites;

    public interface IDictionaryRepository
    {
        Dictionary Get(SiteContext context);
    }
}