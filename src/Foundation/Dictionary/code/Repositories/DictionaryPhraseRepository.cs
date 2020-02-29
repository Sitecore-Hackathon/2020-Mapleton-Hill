
namespace Hackathon.Foundation.Dictionary.Repositories
{
    using Glass.Mapper.Sc;
    using Hackathon.Foundation.Dictionary.Models;
    using Sitecore.Data.Items;

    public class DictionaryPhraseRepository : IDictionaryPhraseRepository
    {
        public DictionaryPhraseRepository(Dictionary dictionary)
        {
            this.Dictionary = dictionary;
        }

        public Dictionary Dictionary { get; set; }
        
        public string Get(string relativePath)
        {
            Item dictionaryItem = this.Dictionary.Root.Axes.GetItem(relativePath);
            
            return dictionaryItem.Fields["Phrase"].Value;
        }
    }
}