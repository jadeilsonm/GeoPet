
using GeoPetAPI.Services;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;

namespace GeoPet.Test
{
    public class NominationServiceTest
    {

        [Fact]
        public async Task ShouldMakeARequest()
        {
            var mockClient = new Mock<HttpClient>();


            var service = new NominationService(mockClient.Object);
            var result = await service.GetInfomatioByLatAndLon("53402","0000");


            result.Should().BeOfType<JsonElement>();

        }

        
    }
}