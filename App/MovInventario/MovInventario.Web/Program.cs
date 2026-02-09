using Microsoft.Data.SqlClient;
using MovInventario.Application.Interfaces;
using MovInventario.Application.Services;
using MovInventario.Infrastructure.Repositories;
using System.Data;

// Permite que Dapper mapee columnas con guion bajo (COD_CIA -> CodCia)
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString =
        sp.GetRequiredService<IConfiguration>()
          .GetConnectionString("DefaultConnection");

    return new SqlConnection(connectionString);
});

builder.Services.AddScoped<IMovInventarioService, MovInventarioService>();
builder.Services.AddScoped<IMovInventarioRepository, MovInventarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
