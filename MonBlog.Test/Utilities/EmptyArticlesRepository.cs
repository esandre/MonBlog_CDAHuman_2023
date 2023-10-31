using MonBlog.Models;
using MonBlog.Ports;

namespace MonBlog.Test.Utilities;

internal class EmptyArticlesRepository : IArticlesRepository
{
    /// <inheritdoc />
    public IEnumerable<Article> FetchAllArticles() => Enumerable.Empty<Article>();

    /// <inheritdoc />
    public Maybe<string> FetchTitle(Permalink permalink) => Maybe<string>.Empty;
}