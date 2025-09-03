using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();   // OpenAPI endpoints
builder.Services.AddSwaggerGen();             // Swagger (Swashbuckle)

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // /swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Health endpoint for quick check
app.MapGet("/", () => Results.Ok(new { ok = true, ts = DateTimeOffset.UtcNow }));

app.MapControllers(); // Maps the WeatherForecast, etc.

app.Run();
