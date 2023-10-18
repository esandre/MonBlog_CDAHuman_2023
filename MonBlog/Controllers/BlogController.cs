using System.Text;
using Microsoft.AspNetCore.Mvc;
using MonBlog.Ports;

namespace MonBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult GetArticles(int limit = 20)
        {
            var articles = _articlesRepository.FetchAllArticles();
            var listItems = articles.Select(article => $"<li>{article.Titre}</li>");

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
}