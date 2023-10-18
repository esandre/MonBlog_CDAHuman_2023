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
        public IActionResult GetArticles()
        {
            var articles = _articlesRepository.FetchArticles();

            var content = string.Concat(Enumerable.Repeat("<li></li>", articles.Count()));

            return Content("<html><body>"
                           + "<div id=\"articles\">" 
                           + $"<ul>{content}</ul>" 
                           + "</div>"
                           + "</body></html>",
                "text/html");
        }
    }
}