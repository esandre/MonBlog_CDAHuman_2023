namespace MonBlog.Ports;

public interface IArticlesRepository
{
    IEnumerable<object> FetchArticles();
}