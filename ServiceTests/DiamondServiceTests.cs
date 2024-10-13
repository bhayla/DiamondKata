using Services;
using FluentAssertions;
using System.Text;

namespace ServiceTests;

public class DiamondServiceTests
{
    [Fact]
    public void DiamondService_InvalidAlphabet_Returns_Null()
    {
        // Arrange
        var ds = new DiamondService();

        // Act 
        var result = ds.Create('?');

        // Assert
        result.Should()
            .BeNull();
    }

    [Fact]
    public void DiamondService_A_Returns_A()
    {
        // Arrange
        var ds = new DiamondService();

        // Act 
        var result = ds.Create('A');

        // Assert
        result.Should()
            .NotBeNull()
            .And.Be("A");
    }

    [Fact]
    public void DiamondService_B_Returns_DiamondB2()
    {
        // Arrange
        var ds = new DiamondService();

        // Act 
        var result = ds.Create('B');

        // Assert
        var B_Diamond = new StringBuilder();
        B_Diamond.AppendLine(" A ");
        B_Diamond.AppendLine("B B");
        B_Diamond.Append(" A ");

        result.Should()
            .NotBeNull()
            .And.Be(B_Diamond.ToString());
    }

    [Fact]
    public void DiamondService_C_Returns_DiamondC2()
    {
        // Arrange
        var ds = new DiamondService();

        // Act 
        var result = ds.Create('C');

        // Assert
        var B_Diamond = new StringBuilder();
        B_Diamond.AppendLine("  A  ");
        B_Diamond.AppendLine(" B B ");
        B_Diamond.AppendLine("C   C");
        B_Diamond.AppendLine(" B B ");
        B_Diamond.Append("  A  ");

        result.Should()
            .NotBeNull()
            .And.Be(B_Diamond.ToString());
    }

    [Theory]
    [InlineData('a')]
    [InlineData('c')]
    public void DiamondService_CapitalLetterAndSmallLetter_ShouldBeSameResult(char character)
    {
        // Arrange
        var ds = new DiamondService();

        // Act 
        var result1 = ds.Create(char.ToUpper(character));
        var result2 = ds.Create(char.ToLower(character));

        // Assert
        result1.Should()
            .Be(result2);
    }
}