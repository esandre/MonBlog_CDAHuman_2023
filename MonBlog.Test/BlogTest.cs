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
        //Assert.SelectorContains("Hello, World", "body>h1", html);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStreamAsync();
        var html = new HtmlDocument();
        html.Load(content);

        var h1 = html.DocumentNode.QuerySelector("body>h1");
        Assert.Contains("Hello, World", h1.InnerText);
    }
}