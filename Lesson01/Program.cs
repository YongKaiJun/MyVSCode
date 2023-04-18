global using Lesson01.Models;
global using Microsoft.AspNetCore.Mvc.Rendering;
global using RP.SOI.DotNet.Services;
global using System.ComponentModel.DataAnnotations;
global using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Inject Services to the container.
builder.Services.AddControllersWithViews();

// Inject Services
builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
