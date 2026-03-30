using Api.Common.Extensions;
using Api.Common.Filters;

namespace Api.Modules.Animals;

public static class AnimalEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapApiGroup("animals");

        group.MapGet("/", (AnimalService service) =>
            TypedResults.Ok(service.GetAll()));

        group.MapGet("/{id:int}", (int id, AnimalService service) =>
        {
            var animal = service.GetById(id);
            return animal is not null
                ? Results.Ok(animal)
                : Results.NotFound();
        });

        group.MapPost("/", (CreateAnimalRequest request, AnimalService service) =>
        {
            var animal = service.Create(request);
            return Results.Created($"/api/animals/{animal.Id}", animal);
        }).AddEndpointFilter<ValidationFilter<CreateAnimalRequest>>();

        group.MapPut("/{id:int}", (int id, UpdateAnimalRequest request, AnimalService service) =>
        {
            var animal = service.Update(id, request);
            return animal is not null
                ? Results.Ok(animal)
                : Results.NotFound();
        }).AddEndpointFilter<ValidationFilter<UpdateAnimalRequest>>();

        group.MapDelete("/{id:int}", (int id, AnimalService service) =>
        {
            return service.Delete(id)
                ? Results.NoContent()
                : Results.NotFound();
        });
    }
}
