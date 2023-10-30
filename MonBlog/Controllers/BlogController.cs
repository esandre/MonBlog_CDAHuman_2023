using System.Text;
using Microsoft.AspNetCore.Mvc;
using MonBlog.Ports;
using MonBlog.Presenters;

namespace MonBlog.Controllers;

[ApiController]
public class BlogController : ControllerBase
{
    private readonly IArticlesRepository _articlesRepository;

    public BlogController(IArticlesRepository articlesRepository)
    {
        _articlesRepository = articlesRepository;
    }

    [HttpGet("/")]
    public IActionResult Get()
    {
        return Content("<html><body>" +
                       "<h1>Hello, World</h1>" +
                       "</body></html>", "text/html");
    }

    [HttpGet("/articles")]
    public IActionResult GetArticles()
    {
        var articles = _articlesRepository.FetchAllArticles();

        var listItems = articles.Select(
            article => new ArticlePermalinkPresenter(article)
        );

        return Content("<html><head>" +
                       $"<meta charset=\"{Encoding.Default.BodyName}\">" +
                       "</head><body>"
                       + "<div id=\"articles\">" 
                       + $"<ul>{string.Concat(listItems)}</ul>" 
                       + "</div>"
                       + "</body></html>",
            "text/html");
    }
}