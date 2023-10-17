using Microsoft.AspNetCore.Mvc;

namespace MonBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get()
        {
            return Content("<html><body><h1>Hello, World</h1></body></html>", "text/html");
        }
    }
}