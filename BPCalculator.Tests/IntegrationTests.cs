using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace BPCalculator.Tests;

public class IntegrationTests
{
    [Fact]
    public async Task HomePage_ReturnsOK()
    {
        using var factory = new WebApplicationFactory<BPCalculator.Program>();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PrivacyPage_ReturnsOK()
    {
        using var factory = new WebApplicationFactory<BPCalculator.Program>();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/privacy");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ErrorPage_ReturnsOK()
    {
        using var factory = new WebApplicationFactory<BPCalculator.Program>();
        var client = factory.CreateClient();

        var response = await client.GetAsync("/error");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}