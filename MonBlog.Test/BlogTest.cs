using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MonBlog.Test;

public class BlogTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BlogTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task HelloWorld()
    {
        var client = _factory.CreateClient();

        // QUAND on fait GET /
        var response = await client.GetAsync("/");

        // ALORS on obtient un Hello World dans le premier titre
        var content = await response.Content.ReadAsStreamAsync();
        Assert.HtmlContainsAt("Hello, World", content, "body>h1");
    }
}