// Program.cs
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ---- EF Core (SQLite)
var cs = builder.Configuration.GetConnectionString("Default") ?? "Data Source=todos.db";
builder.Services.AddDbContext<TodoDb>(opt => opt.UseSqlite(cs));

// ---- Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SimpleApi",
        Version = "v1",
        Description = ""
    });
});

// ---- CORS (open for dev; lock down in prod)
builder.Services.AddCors(o => o.AddPolicy("frontend",
    p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// ---- FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

app.UseCors("frontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ---- Apply migrations & seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoDb>();
    db.Database.Migrate();

    if (!await db.Todos.AnyAsync())
    {
        db.Todos.AddRange(
            new Todo { Text = "Learn .NET", Done = false },
            new Todo { Text = "Build an API", Done = true }
        );
        await db.SaveChangesAsync();
    }
}

// ---- Validation helper
IResult ValidationFailure(ValidationResult v) =>
    Results.ValidationProblem(v.Errors
        .GroupBy(e => e.PropertyName)
        .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray()));

// ---- Endpoints
app.MapGet("/api/todos", async (TodoDb db) =>
    await db.Todos.AsNoTracking().OrderByDescending(t => t.Id).ToListAsync());

app.MapGet("/api/todos/{id:int}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id) is { } t ? Results.Ok(t) : Results.NotFound());

app.MapPost("/api/todos", async (
    [FromBody] CreateTodo dto,
    IValidator<CreateTodo> validator,
    TodoDb db) =>
{
    var val = await validator.ValidateAsync(dto);
    if (!val.IsValid) return ValidationFailure(val);

    var todo = new Todo { Text = dto.Text, Done = false };
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/api/todos/{todo.Id}", todo);
});

app.MapPut("/api/todos/{id:int}", async (
    int id,
    [FromBody] UpdateTodo dto,
    IValidator<UpdateTodo> validator,
    TodoDb db) =>
{
    var val = await validator.ValidateAsync(dto);
    if (!val.IsValid) return ValidationFailure(val);

    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    if (dto.Text is not null) todo.Text = dto.Text;
    if (dto.Done is not null) todo.Done = dto.Done.Value;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/todos/{id:int}", async (int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();
    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();


// =======================
// Below are simple types so this file is self-contained.
// If you already created separate files for these, delete
// this region or remove the duplicates.
// =======================

public class Todo
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public bool Done { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}

public record CreateTodo(string Text);
public record UpdateTodo(string? Text, bool? Done);

public class CreateTodoValidator : AbstractValidator<CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Text is required")
            .MaximumLength(200);
    }
}

public class UpdateTodoValidator : AbstractValidator<UpdateTodo>
{
    public UpdateTodoValidator()
    {
        RuleFor(x => x.Text)
            .MaximumLength(200)
            .When(x => x.Text is not null);
    }
}

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }
    public DbSet<Todo> Todos => Set<Todo>();
}
