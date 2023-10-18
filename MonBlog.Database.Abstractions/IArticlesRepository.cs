namespace MonBlog.Database.Abstractions;

public interface IArticlesRepository
{
    IEnumerable<Article> FetchAllArticles();
}