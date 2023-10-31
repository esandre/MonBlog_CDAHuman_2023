using MonBlog.Models;

namespace MonBlog.Ports;

public interface IArticlesRepository
{
    IEnumerable<Article> FetchAllArticles();
    Maybe<string> FetchTitle(Permalink permalink);
}