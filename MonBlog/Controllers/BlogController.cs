using System.Text;
using Microsoft.AspNetCore.Mvc;
using MonBlog.Repositories;

namespace MonBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public BlogController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            return Content("<html><body><h1>Hello, World</h1></body></html>", "text/html");
        }

        [HttpGet("/articles")]
        public IActionResult GetArticles()
        {
            return Ok(_articleRepository.FetchArticles());
        }
    }
}