
using GeoPetAPI.Services;
using Moq;
using System.Text.Json;

namespace GeoPet.Test
{
    public class ViaCepServiceTest
    {
        [Fact]
        public async Task ShouldMakeARequestNull()
        {
            var mockClient = new Mock<HttpClient>();


            var viaCepService = new ViaCepService(mockClient.Object);
            var result = await viaCepService.FindCep("53402");


            result.Should().BeNull();
            
        }

        [Fact]
        public async Task ShouldMakeARequest()
        {
            var mockClient = new Mock<HttpClient>();


            var viaCepService = new ViaCepService(mockClient.Object);
            var result = await viaCepService.FindCep("53402000");


            result.Should().BeOfType<JsonElement>();

        }
    }
}