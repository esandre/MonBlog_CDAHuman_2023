using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using MonBlog.Test.Utilities;

namespace MonBlog.Test;

public class PermalinkSecurityTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public PermalinkSecurityTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("ab-12A")] // Majuscule interdite
    [InlineData("ab-12_")] // Underscore interdit
    [InlineData("ab-12daaaaaaaaaaaaaaaaaaaaaaaaaaaaat1")] // Trop long (37 caractères)
    [InlineData("1")] // Trop court (1 caractère)
    public async Task PermalinkUnallowedValuesTest(string valueToTest)
    {
        // ETANT DONNE un blog 
        var client = new ClientBuilder(_factory).Build();

        // QUAND on fait GET /articles/<permalien>
        var response = await client.GetAsync($"/articles/{valueToTest}");

        // ALORS on obtient une réponse HTTP 400 Bad Request
        var returnCode = response.StatusCode;
        Assert.Equal(HttpStatusCode.BadRequest, returnCode);
    }
}