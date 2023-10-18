using MonBlog.Models;

namespace MonBlog.Ports;

public interface IArticlesRepository
{
    IEnumerable<Article> FetchAllArticles();
    Article FindByPermalink(Permalink permalink);
}