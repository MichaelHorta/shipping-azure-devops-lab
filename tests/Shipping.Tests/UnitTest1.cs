using Shipping.Api;
using Xunit;

namespace Shipping.Tests;

public class ShippingCalculatorTests
{
    [Theory]
    [InlineData(1, 2500)]
    [InlineData(2, 3000)]
    [InlineData(5, 4500)]
    [InlineData(10, 0)]
    public void Calculate_ReturnsExpectedQuote(
        int weightKg,
        int expectedAmount)
    {
        var actual = ShippingCalculator.Calculate(weightKg);

        Assert.Equal((decimal)expectedAmount, actual);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Calculate_RejectsNonPositiveWeights(int weightKg)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => ShippingCalculator.Calculate(weightKg));
    }
}