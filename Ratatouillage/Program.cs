using Microsoft.Data.SqlClient;
using Ratatouillage.Core.Interfaces.Repository;
using Ratatouillage.Core.Services;
using Ratatouillage.External.Repository;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// - Connection SQL
builder.Services.AddScoped<IDbConnection>((service) =>
{
    return new SqlConnection(builder.Configuration.GetConnectionString("default"));
});
// - Repository
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
// - Core
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
