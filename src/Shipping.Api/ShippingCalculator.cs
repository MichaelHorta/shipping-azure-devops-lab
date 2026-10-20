namespace Shipping.Api;

public static class ShippingCalculator
{
    public static decimal Calculate(decimal weightKg)
    {
        if (weightKg <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(weightKg),
                "Weight must be greater than zero.");
        }

        if (weightKg >= 10)
        {
            return 0m;
        }

        // Fictional pricing for this exercise.
        return 2_000m + weightKg * 500m;
    }
}