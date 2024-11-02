using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// A�adir CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configura el servicio de MySQL con la versi�n correcta
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(9, 1, 0))));  // Cambia a tu versi�n de MySQL

// Otros servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger para documentaci�n
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTodo");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
