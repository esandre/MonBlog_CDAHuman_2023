using MonBlog.Ports;

namespace MonBlog.Test.Utilities;

internal class EmptyArticlesRepository : IArticlesRepository
{
    /// <inheritdoc />
    public IEnumerable<object> FetchArticles()
    {
        return Enumerable.Empty<object>();
    }
}