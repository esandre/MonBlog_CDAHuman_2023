using MonBlog.Models;
using MonBlog.Ports;

namespace MonBlog.Test.Utilities;

internal class EmptyArticlesRepository : IArticlesRepository
{
    /// <inheritdoc />
    public IEnumerable<Article> FetchAllArticles()
    {
        return Enumerable.Empty<Article>();
    }
}