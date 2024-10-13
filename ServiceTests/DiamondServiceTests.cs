using Services;
using FluentAssertions;

namespace ServiceTests;

public class DiamondServiceTests
{
    [Fact]
    public void DiamondService_A_Returns_A()
    {
        // Arrange
        var ds = new DiamondService();

        // Act 
        var result = ds.Create('A');

        // Assert
        result.Should()
            .NotBeNull();
    }
}