using Api.Features.Animals;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

AnimalEndpoints.Map(app);

app.Run();
