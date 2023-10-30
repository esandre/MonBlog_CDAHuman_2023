using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace MonBlog.Test.Utilities;

internal class ClientBuilder
{
    public static HttpClient Default(WebApplicationFactory<Program> aspNetBuilder)
        => new ClientBuilder(aspNetBuilder).Build();

    private readonly WebApplicationFactory<Program> _aspNetBuilder;

    public ClientBuilder(WebApplicationFactory<Program> aspNetBuilder)
    {
        _aspNetBuilder = aspNetBuilder;
    }

    public ClientBuilder ReplacingService<TDependency>(TDependency replacement) 
        where TDependency : class
    {
        return new ClientBuilder(
            _aspNetBuilder.WithWebHostBuilder(
                builder => builder.ConfigureServices(
                    container => container.AddSingleton(replacement)
                )
            )
        );
    }

    public HttpClient Build() => _aspNetBuilder.CreateClient();
}