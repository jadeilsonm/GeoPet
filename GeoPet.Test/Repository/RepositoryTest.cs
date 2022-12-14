using GeoPetAPI.Controllers;
using GeoPetAPI.Models;
using GeoPetAPI.Services;
using GeoPetAPI.Shared.Contracts;
using Moq;

namespace GeoPet.Test.Repository;

public class RepositoryTest
{
    [Fact(DisplayName = "GeoPetRepository returns pets")]
    public void GeoPetShouldReturnsPets()
    {
        var repository = new Mock<IGeoPetRepository>();
        var pets = new List<Pet>() {
            new Pet {
                PetId = 1,
                Name = "Pet 1",
                Age = 1,
                Carry = GeoPetAPI.Shared.Enuns.Carry.medium,
                PeopleId = 1,
                Breed = "test"
            },
           new Pet {
                PetId = 2,
                Name = "Pet 2",
                Age = 1,
                Carry = GeoPetAPI.Shared.Enuns.Carry.medium,
                PeopleId = 2,
                Breed = "test"
            },
           new Pet {
                PetId = 3,
                Name = "Pet 3",
                Age = 1,
                Carry = GeoPetAPI.Shared.Enuns.Carry.medium,
                PeopleId = 3,
                Breed = "test"
            }};
        repository.Setup(r => r.GetPets()).Returns(pets);


        var sut = new PetsController(repository.Object);

        var results = sut.GetPets();


        Assert.NotNull(results);

    }

    [Fact(DisplayName = "GeoPetRepository returns peoples")]
    public void GeoPetShouldreturnsPeoples()
    {
        var mockClient = new Mock<HttpClient>();


        var viaCepService = new ViaCepService(mockClient.Object);
        var repository = new Mock<IGeoPetRepository>();
        var peoples = new List<People>() {
            new People {
                PeopleId = 1,
                Name = "test",
                Cep = "00000000",
                Email = "test@test.com",
                Password = "password",
            },
           new People {
                PeopleId = 3,
                Name = "test2",
                Cep = "00000002",
                Email = "test2@test.com",
                Password = "password2",
            },
            new People {
                PeopleId = 3,
                Name = "test3",
                Cep = "00000003",
                Email = "test3@test.com",
                Password = "password3",
            }};
        repository.Setup(r => r.GetPeoples()).Returns(peoples);


        var sut = new CaregiverPeolpleController(repository.Object, viaCepService);

        var results = sut.GetPeoples();

       

        Assert.NotNull(results);
    }

    [Fact(DisplayName = "GeoPetRepository returns peoples")]
    public void GeoPetShouldreturnsPeople()
    {
        var mockClient = new Mock<HttpClient>();


        var viaCepService = new ViaCepService(mockClient.Object);
        var repository = new Mock<IGeoPetRepository>();
        var people =
            new People
            {
                PeopleId = 1,
                Name = "test",
                Cep = "00000000",
                Email = "test@test.com",
                Password = "password",
            };
        repository.Setup(r => r.GetPeople(1)).Returns(people);


        var sut = new CaregiverPeolpleController(repository.Object, viaCepService);

        var results = sut.GetPeople(1);

        var okResolt = results as People;

        Assert.NotNull(results);

    }
}
