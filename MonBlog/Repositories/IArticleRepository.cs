using MonBlog.Models;

namespace MonBlog.Repositories;

public interface IArticleRepository
{
    IEnumerable<Article> FetchArticles();
}