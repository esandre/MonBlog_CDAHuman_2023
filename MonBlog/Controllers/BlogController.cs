using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MonBlog.Ports;

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

    public IActionResult FillForm([FromBody] FormDataInputContract input)
    {
        return Ok();
    }

    /**
     * {
     *  userId= "test",
     *  dateOfTheEvent= "2023-05-12",
     *  nomberOfBugs= 8
     * }
     */

    public record FormDataInputContract(string UserId, DateTime DateOfTheEvent, int? NumberOfBugs);

    [HttpGet("/articles")]
    public IActionResult GetArticles()
    {
        var articles = _articlesRepository.FetchAllArticles();

        var listItems = articles.Select(
            article => $"<li><a href=\"/articles/{article.Permalink}\">{article.Titre}</a></li>"
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