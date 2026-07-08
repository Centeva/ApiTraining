using ApiTraining.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = Path.Join(path, "contacts.db");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
