using MonBlog.Models;
using MonBlog.Ports;

namespace MonBlog.Test.Utilities;

internal class ExampleArticlesRepository : IArticlesRepository
{
    public IDictionary<string, string> PermalinksAndTitles { get; }

    public ExampleArticlesRepository(int numberOfArticles = 3)
    {
        PermalinksAndTitles = Enumerable.Range(1, numberOfArticles)
            .ToDictionary(n => $"article-{n}", n => $"Mon article n°{n}");
    }

    /// <inheritdoc />
    public IEnumerable<Article> FetchAllArticles()
    {
        return PermalinksAndTitles.Select(pair => new Article(pair.Key, pair.Value));
    }

    /// <inheritdoc />
    public Maybe<string> FetchTitle(Permalink permalink)
    {
        try
        {
            return PermalinksAndTitles[permalink.Value];
        }
        catch (KeyNotFoundException)
        {
            return Maybe<string>.Empty;
        }
    }
}