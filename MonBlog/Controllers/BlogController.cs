using System.Text;
using Microsoft.AspNetCore.Mvc;
using MonBlog.Models;
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

    /// <summary>
    /// Récupère un article selon son permalien
    /// </summary>
    /// <param name="permalink">Le permalien, un string de 2 à 36 caractères, lettres minuscules, chiffres et tirets</param>
    /// <response code="200">Retourne le HTML contenant le titre de l'article</response>
    /// <response code="400">Le permalien est mal formé</response>
    [HttpGet("/articles/{permalink}")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(400, Type = typeof(string))]
    public IActionResult GetArticle(string permalink)
    {
        try
        {
            var titre = _articlesRepository.FetchTitle(new Permalink(permalink));

            return Content("<html><head>" +
                           $"<meta charset=\"{Encoding.Default.BodyName}\">" +
                           "</head><body>"
                           + "<article>"
                           + $"<h1>{titre}</h1>"
                           + "</article>"
                           + "</body></html>",
                "text/html");
        } 
        catch(ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }
}