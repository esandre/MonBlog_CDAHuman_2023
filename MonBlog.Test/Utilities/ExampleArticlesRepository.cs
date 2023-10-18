using MonBlog.Ports;

namespace MonBlog.Test.Utilities;

internal class ExampleArticlesRepository : IArticlesRepository
{
    public ushort NombreArticles => 2;

    /// <inheritdoc />
    public IEnumerable<object> FetchArticles()
    {
        return new[] { new object(), new object() };
    }
}