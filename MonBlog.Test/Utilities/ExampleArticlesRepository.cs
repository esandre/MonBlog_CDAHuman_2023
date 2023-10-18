using MonBlog.Models;
using MonBlog.Ports;

namespace MonBlog.Test.Utilities;

internal class ExampleArticlesRepository : IArticlesRepository
{
    public static readonly IEnumerable<string> Titles 
        = new[] { "Premier article", "Second article", "Troisième article" };

    /// <inheritdoc />
    public IEnumerable<Article> FetchAllArticles()
    {
        return Titles.Select(title => new Article(title));
    }
}