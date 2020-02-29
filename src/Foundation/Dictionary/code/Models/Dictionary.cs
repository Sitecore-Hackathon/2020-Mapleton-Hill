using Sitecore.Data.Items;
using Sitecore.Sites;

namespace Hackathon.Foundation.Dictionary.Models
{
    public class Dictionary
    {
        public Item Root { get; set; }
        public SiteContext Site { get; set; }
    }
}