using Api.Modules.Animals;

namespace Api.Tests;

public class AnimalServiceTests
{
    private readonly AnimalService _sut = new();

    [Fact]
    public void GetAll_ReturnsSeededAnimals()
    {
        var animals = _sut.GetAll();

        Assert.Equal(5, animals.Count);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsAnimal()
    {
        var animal = _sut.GetById(1);

        Assert.NotNull(animal);
        Assert.Equal("Buddy", animal.Name);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        var animal = _sut.GetById(999);

        Assert.Null(animal);
    }

    [Fact]
    public void Create_AddsAnimalAndReturnsIt()
    {
        var request = new CreateAnimalRequest
        {
            Name = "Rex",
            Species = "Dog",
            Age = 2
        };

        var created = _sut.Create(request);

        Assert.Equal("Rex", created.Name);
        Assert.Equal("Dog", created.Species);
        Assert.Equal(2, created.Age);
        Assert.Equal(6, _sut.GetAll().Count);
    }

    [Fact]
    public void Delete_ExistingId_ReturnsTrueAndRemoves()
    {
        var result = _sut.Delete(1);

        Assert.True(result);
        Assert.Equal(4, _sut.GetAll().Count);
        Assert.Null(_sut.GetById(1));
    }

    [Fact]
    public void Delete_NonExistingId_ReturnsFalse()
    {
        var result = _sut.Delete(999);

        Assert.False(result);
    }
}
