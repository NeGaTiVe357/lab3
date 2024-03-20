using lab3;
using Microsoft.EntityFrameworkCore;
using System.Data.Odbc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.

//BD
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    // Создаем строку подключения к базе данных MySQL
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Устанавливаем провайдер данных как MySQL
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// В методе ConfigureServices в Startup.cs


// В методе Configure в Startup.cs
app.UseCors("AllowOrigin");

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