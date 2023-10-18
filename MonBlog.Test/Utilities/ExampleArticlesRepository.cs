using MonBlog.Models;
using MonBlog.Ports;

namespace MonBlog.Test.Utilities;

internal class ExampleArticlesRepository : IArticlesRepository
{
    public static readonly IDictionary<string, string> PermalinksAndTitles 
        = new Dictionary<string, string>()
            {
                { "premier-article", "Premier Article" },
                { "second-article", "Second Article" },
                { "troisième-article", "Troisième Article" },
            };

    /// <inheritdoc />
    public IEnumerable<Article> FetchAllArticles()
    {
        return PermalinksAndTitles.Select(pair => new Article(pair.Key, pair.Value));
    }
}