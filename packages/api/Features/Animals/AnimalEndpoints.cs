using Api.Common.Extensions;

namespace Api.Features.Animals;

public static class AnimalEndpoints
{
    private static readonly List<Animal> Animals =
    [
        new(1, "Buddy", "Dog", 3),
        new(2, "Whiskers", "Cat", 5),
        new(3, "Polly", "Parrot", 2),
        new(4, "Nemo", "Fish", 1),
        new(5, "Thumper", "Rabbit", 4)
    ];

    private static int _nextId = 6;

    public static void Map(WebApplication app)
    {
        var group = app.MapApiGroup("animals");

        group.MapGet("/", () => Animals);

        group.MapGet("/{id:int}", (int id) =>
        {
            var animal = Animals.FirstOrDefault(a => a.Id == id);
            return animal is not null ? Results.Ok(animal) : Results.NotFound();
        });

        group.MapPost("/", (CreateAnimalRequest request) =>
        {
            var animal = new Animal(_nextId++, request.Name, request.Species, request.Age);
            Animals.Add(animal);
            return Results.Created($"/api/animals/{animal.Id}", animal);
        });

        group.MapPut("/{id:int}", (int id, UpdateAnimalRequest request) =>
        {
            var index = Animals.FindIndex(a => a.Id == id);
            if (index == -1) return Results.NotFound();

            Animals[index] = new Animal(id, request.Name, request.Species, request.Age);
            return Results.Ok(Animals[index]);
        });

        group.MapDelete("/{id:int}", (int id) =>
        {
            var animal = Animals.FirstOrDefault(a => a.Id == id);
            if (animal is null) return Results.NotFound();

            Animals.Remove(animal);
            return Results.NoContent();
        });
    }
}

public record CreateAnimalRequest(string Name, string Species, int Age);
public record UpdateAnimalRequest(string Name, string Species, int Age);
