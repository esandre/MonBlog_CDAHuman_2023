using MonBlog.Models;

namespace MonBlog.Ports;

public interface IArticlesRepository
{
    IEnumerable<Article> FetchAllArticles();
    string? FetchTitle(Permalink permalink);
}