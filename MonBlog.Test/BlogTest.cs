using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MonBlog.Ports;
using MonBlog.Test.Utilities;

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

    [Fact]
    public async Task GetWithoutArticles()
    {
        // ETANT DONNE un blog sans articles
        var customFactory = _factory.WithWebHostBuilder(
            builder => builder.ConfigureServices(
                container => container.AddSingleton<IArticlesRepository>(new EmptyArticlesRepository()))
        );

        var client = customFactory.CreateClient();

        // QUAND on fait GET /articles
        var response = await client.GetAsync("/articles");

        // ALORS on obtient une <ul> vide
        var content = await response.Content.ReadAsStreamAsync();
        Assert.HtmlContainsAt("", content, "#articles>ul");
    }

    [Fact]
    public async Task GetWithArticles()
    {
        // ETANT DONNE un blog ayant des articles
        var repo = new ExampleArticlesRepository();

        var customFactory = _factory.WithWebHostBuilder(
            builder => builder.ConfigureServices(
                container => container.AddSingleton<IArticlesRepository>(repo))
        );

        var client = customFactory.CreateClient();

        // QUAND on fait GET /articles
        var response = await client.GetAsync("/articles");

        // ALORS on obtient une <ul> ayant un <li> par article
        var content = await response.Content.ReadAsStreamAsync();
        Assert.CountChildrenOfType(repo.NombreArticles, content, "#articles>ul", "li");
    }
}