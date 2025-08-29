using Microsoft.EntityFrameworkCore;
using TodoMvc.Data;

var builder = WebApplication.CreateBuilder(args);

// MVC + Razor (already added by template)
builder.Services.AddControllersWithViews();

// EF Core (SQLite)
var cs = builder.Configuration.GetConnectionString("Default") ?? "Data Source=todos_mvc.db";
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(cs));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default route -> Todos/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todos}/{action=Index}/{id?}");

// Auto-migrate & seed a couple rows (dev convenience)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    if (!db.Todos.Any())
    {
        db.Todos.AddRange(
            new TodoMvc.Models.Todo { Text = "Try MVC app", Done = false },
            new TodoMvc.Models.Todo { Text = "Show it in workshop", Done = true }
        );
        db.SaveChanges();
    }
}

app.Run();
