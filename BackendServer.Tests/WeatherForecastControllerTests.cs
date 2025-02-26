using BackendServer1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace BackendServer.Tests;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsServerNameFromConfiguration()
    {
        // Arrange
        var inMemorySettings = new Dictionary<string, string>
            {
                {"SERVER_NAME", "TestServer"}
            };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var mockLogger = new Mock<ILogger<WeatherForecastController>>();
        var controller = new WeatherForecastController(mockLogger.Object, configuration);

        // Act
        var result = controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        var responseData = result.Value as dynamic;
        Assert.Equal("TestServer", responseData.Server);
    }
}
