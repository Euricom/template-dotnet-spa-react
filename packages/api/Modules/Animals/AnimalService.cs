namespace Api.Modules.Animals;

public class AnimalService
{
    private readonly List<Animal> _animals =
    [
        new() { Id = 1, Name = "Buddy", Species = "Dog", Age = 3 },
        new() { Id = 2, Name = "Whiskers", Species = "Cat", Age = 5 },
        new() { Id = 3, Name = "Polly", Species = "Parrot", Age = 2 },
        new() { Id = 4, Name = "Nemo", Species = "Fish", Age = 1 },
        new() { Id = 5, Name = "Thumper", Species = "Rabbit", Age = 4 }
    ];

    private int _nextId = 6;

    public List<Animal> GetAll() => _animals;

    public Animal? GetById(int id) => _animals.FirstOrDefault(a => a.Id == id);

    public Animal Create(CreateAnimalRequest request)
    {
        var animal = new Animal
        {
            Id = _nextId++,
            Name = request.Name,
            Species = request.Species,
            Age = request.Age
        };
        _animals.Add(animal);
        return animal;
    }

    public Animal? Update(int id, UpdateAnimalRequest request)
    {
        var index = _animals.FindIndex(a => a.Id == id);
        if (index == -1) return null;

        _animals[index] = new Animal
        {
            Id = id,
            Name = request.Name,
            Species = request.Species,
            Age = request.Age
        };
        return _animals[index];
    }

    public bool Delete(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal is null) return false;

        _animals.Remove(animal);
        return true;
    }
}
