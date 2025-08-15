using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using movieTheatre.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? "Data Source=movieTheatre.db";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    if (!db.Categories.Any())
    {
        db.Categories.AddRange(
            new movieTheatre.Models.Category { Name = "Action", Code = "ACT" },
            new movieTheatre.Models.Category { Name = "Drama", Code = "DRM" },
            new movieTheatre.Models.Category { Name = "Horror", Code = "HOR" }
        );
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllers();

app.Run();