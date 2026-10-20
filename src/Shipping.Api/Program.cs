using Shipping.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.MapGet("/shipping/quote", (decimal weightKg) =>
{
    if (weightKg <= 0)
    {
        return Results.BadRequest(new
        {
            error = "Weight must be greater than zero."
        });
    }

    return Results.Ok(new
    {
        weightKg,
        amount = ShippingCalculator.Calculate(weightKg),
        currency = "CLP"
    });
});

app.Run();