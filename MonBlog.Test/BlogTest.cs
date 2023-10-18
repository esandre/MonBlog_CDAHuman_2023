using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MonBlog.Ports;
using MonBlog.Test.Utilities;
using System.Text;

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
        var client = ClientBuilder.Default(_factory);

        // QUAND on fait GET /
        var response = await client.GetAsync("/");

        // ALORS on obtient un Hello World dans le premier titre
        var content = await response.Content.ReadAsStringAsync();
        Assert.HtmlContainsAt("Hello, World", content, "body>h1");
    }

    [Fact]
    public async Task MetaCharsetPresent()
    {
        var client = ClientBuilder.Default(_factory);
        var response = await client.GetAsync("/articles");

        var content = await response.Content.ReadAsStringAsync();
        Assert.HtmlAttributeHasValue(Encoding.Default.BodyName, content, "meta", "charset");
    }

    [Fact]
    public async Task GetWithoutArticles()
    {
        // ETANT DONNE un blog sans articles
        var client = new ClientBuilder(_factory)
            .ReplacingService<IArticlesRepository>(new EmptyArticlesRepository())
            .Build();

        // QUAND on fait GET /articles
        var response = await client.GetAsync("/articles");

        // ALORS on obtient une <ul> vide
        var content = await response.Content.ReadAsStringAsync();
        Assert.HtmlContainsAt("", content, "#articles>ul");
    }

    [Fact]
    public async Task GetWithArticles()
    {
        // ETANT DONNE un blog ayant des articles
        var repo = new ExampleArticlesRepository();
        var client = new ClientBuilder(_factory)
            .ReplacingService<IArticlesRepository>(repo)
            .Build();

        // QUAND on fait GET /articles
        var response = await client.GetAsync("/articles");

        // ALORS on obtient une <ul> ayant un <li><a> par article contenant son titre
        // ET pointant vers le permalien de l'article
        var content = await response.Content.ReadAsStringAsync();

        foreach (var (permalink, title) in ExampleArticlesRepository.PermalinksAndTitles)
        {
            Assert.HtmlContainsAt(title, content, "#articles>ul>li>a");
            Assert.HtmlAttributeHasValue("/articles/" + permalink, content, "#articles>ul>li>a", "href");
        }
    }
}