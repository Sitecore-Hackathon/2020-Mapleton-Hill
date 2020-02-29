using Sitecore.Data.Items;

namespace Hackathon.Foundation.Dictionary.Repositories
{
    using Hackathon.Foundation.Dictionary.Models;
    public interface IDictionaryPhraseRepository
    {
        string Get(string relativePath);
        Dictionary Dictionary { get; set; }
    }
}
