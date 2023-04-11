namespace PetShop.Test;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShopApiServise.Models;
using PetShopApiServise.Reposetories.Data;

[TestClass]
public class AnimalCrudTest
{
    private DataRepository<Animals> ? _repository;

    [TestInitialize]
    public void Initialize()
    {
        var options = new DbContextOptionsBuilder<PetShopDBContext>()
            .UseInMemoryDatabase(databaseName: "PetShopTest")
            .Options;

        var context = new PetShopDBContext(options);
        _repository = new DataRepository<Animals>(context);
    }

    [TestMethod]
    public async Task TestPostAndGetAll()
    {
        // Arrange
        var animal = new Animals { Name = "Fluffy" };

        // Act
        await _repository.Post(animal);
        var animals = await _repository.GetAll();

        // Assert
        Assert.AreEqual(1, animals.Count());
        Assert.AreEqual("Fluffy", animals.First().Name);
    }

    [TestMethod]
    public async Task TestGetById()
    {
        // Arrange
        var animal1 = new Animals { Name = "Fluffy", Age=2 , CategoryId=1, Picture = new byte[0] { }, Description="asdasd",  };
        var animal2 = new Animals { Name = "Fluffy", Age = 2, CategoryId = 1, Picture = new byte[0] { }, Description = "asdasd", };
        await _repository.Post(animal1);
        await _repository.Post(animal2);

        // Act
        var retrievedAnimal = await _repository.GetById(animal1.AnimalId);

        // Assert
        Assert.AreEqual("Fluffy", retrievedAnimal.Name);
        Assert.AreEqual("Dog", retrievedAnimal.Name);
    }

    [TestMethod]
    public async Task TestPut()
    {
        // Arrange
        var animal = new Animals { Name = "Fluffy", Age = 2, CategoryId = 1, Picture = new byte[0] { }, Description = "asdasd", };
        await _repository.Post(animal);

        // Act
        animal.Name = "Cat";
        await _repository.Put(animal);

        // Assert
        var retrievedAnimal = await _repository.GetById(animal.AnimalId);
        Assert.AreEqual("Cat", retrievedAnimal.Name);
    }

    [TestMethod]
    public async Task TestDeleteById()
    {
        // Arrange
        var animal1 = new Animals { Name = "Fluffy", Age = 2, CategoryId = 1, Picture = new byte[0] { }, Description = "asdasd", };
        var animal2 = new Animals { Name = "Fluffy", Age = 2, CategoryId = 1, Picture = new byte[0] { }, Description = "asdasd", };
        await _repository!.Post(animal1);
        await _repository.Post(animal2);

        // Act
        var result = await _repository.DeleteById(animal1.AnimalId);

        // Assert
        Assert.AreEqual(1, result);

    }

}

