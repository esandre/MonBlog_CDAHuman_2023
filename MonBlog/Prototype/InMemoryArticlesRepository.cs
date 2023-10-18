using MonBlog.Ports;

namespace MonBlog.Prototype;

public class InMemoryArticlesRepository : IArticlesRepository
{
    /// <inheritdoc />
    public IEnumerable<object> FetchArticles()
    {
        return Enumerable.Empty<object>();
    }
}