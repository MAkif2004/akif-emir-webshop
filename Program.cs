using Microsoft.EntityFrameworkCore;
using WebShopLearning.Models;
using WebShopLearning.Services;
using WebShopLearning.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers().AddNewtonsoftJson(delegate (MvcNewtonsoftJsonOptions options)
{
    options.SerializerSettings.ReferenceLoopHandling = (ReferenceLoopHandling)1;
});

builder.Services.AddDbContext<WebShopLearningDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(11, 8, 2)) // use version close to your MariaDB version
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
