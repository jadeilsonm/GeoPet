using Microsoft.EntityFrameworkCore;

using GeoPetAPI.Shared.Repositories;
using GeoPetAPI.Models;
using GeoPetAPI.Shared.Constants;

namespace BookingApi.Test
{
    public static class Helpers
    {
        public static GeoPetContext GetContextInstanceForTests(string inMemoryDbName)
        {
            var contextOptions = new DbContextOptionsBuilder<GeoPetContext>()
                .UseInMemoryDatabase(inMemoryDbName)
                .Options;
            var context = new GeoPetContext(contextOptions);
            context.Peoples.AddRange(
                GetPeoplelListForTests()
            );
            context.SaveChanges();
            context.Pets.AddRange(
                GetUserListForTests()
            );
            context.SaveChanges();
            return context;
        }

        public static List<People> GetPeoplelListForTests() =>
        new() {
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
            }
        };

        public static List<Pet> GetUserListForTests() =>
        new() {
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
            },
        };

    }
}