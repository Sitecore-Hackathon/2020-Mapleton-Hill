namespace Hackathon.Foundation.Dictionary.Factories
{
    using Hackathon.Foundation.Dictionary.Models;
    using Hackathon.Foundation.Dictionary.Repositories;

    public static class DictionaryFactory
    {
        public static Dictionary Build()
        {
            var dictionaryRepo = new DictionaryRepository();

            Dictionary dictionary = dictionaryRepo.Get(Sitecore.Context.Site);

            return dictionary;
        }
    }
}