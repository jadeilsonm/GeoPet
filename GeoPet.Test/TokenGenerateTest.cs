using GeoPetAPI.Models;
using GeoPetAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoPet.Test;

public class TokenGenerateTest
{
    [Theory(DisplayName = "Teste para TokenGenerator em que token não é nulo")]
    [InlineData("Mayara", "mayara@gmail.com", "54892000", "password123")]
    public void TestTokenGeneratorSuccess(string name, string email, string cep, string password)
    {
        var client = new People()
        {
            Name = name,
            Cep = cep,
            Password = password,
            Email = email
        };
        var tokenGenerator = new TokenGenerator();
        var token = tokenGenerator.Generate(client);
        token.Should().NotBeNullOrWhiteSpace();
    }

    
    [Theory(DisplayName = "Teste para TokenGenerator em que token JWT possui 3 partes")]
    [InlineData("Mayara", "mayara@gmail.com", "54892000", "password123")]
    public void TestTokenGeneratorKeysSuccess(string name, string email, string cep, string password)
    {
        var client = new People()
        {
            Name = name,
            Cep = cep,
            Password = password,
            Email = email
        };
        var tokenGenerator = new TokenGenerator();
        var token = tokenGenerator.Generate(client);
        token.Split('.').Length.Should().Be(3);
    }
}
