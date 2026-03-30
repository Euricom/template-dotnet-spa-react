using System.Net;
using System.Net.Http.Json;
using Api.Modules.Animals;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Api.Tests.Integration;

public class AnimalEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AnimalEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAnimals_ReturnsOkWithAnimals()
    {
        var response = await _client.GetAsync("/api/animals");

        response.EnsureSuccessStatusCode();
        var animals = await response.Content.ReadFromJsonAsync<List<Animal>>();
        Assert.NotNull(animals);
        Assert.True(animals.Count >= 5);
    }

    [Fact]
    public async Task GetAnimalById_ExistingId_ReturnsOk()
    {
        var response = await _client.GetAsync("/api/animals/1");

        response.EnsureSuccessStatusCode();
        var animal = await response.Content.ReadFromJsonAsync<Animal>();
        Assert.NotNull(animal);
        Assert.Equal("Buddy", animal.Name);
    }

    [Fact]
    public async Task GetAnimalById_NonExistingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/animals/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateAnimal_ValidRequest_ReturnsCreated()
    {
        var request = new CreateAnimalRequest
        {
            Name = "Rex",
            Species = "Dog",
            Age = 2
        };

        var response = await _client.PostAsJsonAsync("/api/animals", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var animal = await response.Content.ReadFromJsonAsync<Animal>();
        Assert.NotNull(animal);
        Assert.Equal("Rex", animal.Name);
    }

    [Fact]
    public async Task CreateAnimal_InvalidRequest_ReturnsBadRequest()
    {
        var request = new CreateAnimalRequest
        {
            Name = "",
            Species = "",
            Age = -1
        };

        var response = await _client.PostAsJsonAsync("/api/animals", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DeleteAnimal_NonExistingId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/animals/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
