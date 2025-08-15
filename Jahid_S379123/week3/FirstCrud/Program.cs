using FirstCrud.Data;
using FirstCrud.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// SQLite database file in project root
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=app.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Auto-apply migrations (dev convenience)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ---- CRUD ----

// READ all
app.MapGet("/products", async (AppDbContext db) =>
    await db.Products.AsNoTracking().ToListAsync());

// READ one
app.MapGet("/products/{id:int}", async (int id, AppDbContext db) =>
    await db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id)
        is { } p ? Results.Ok(p) : Results.NotFound());

// CREATE
app.MapPost("/products", async (Product input, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(input.Name))
        return Results.BadRequest("Name is required.");

    db.Products.Add(input);
    await db.SaveChangesAsync();
    return Results.Created($"/products/{input.Id}", input);
});

// UPDATE
app.MapPut("/products/{id:int}", async (int id, Product update, AppDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    if (product is null) return Results.NotFound();

    product.Name  = update.Name;
    product.Price = update.Price;
    product.Stock = update.Stock;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// DELETE
app.MapDelete("/products/{id:int}", async (int id, AppDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    if (product is null) return Results.NotFound();

    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
