using Microsoft.EntityFrameworkCore;
using LibreriaDigitalApi.Data;
using LibreriaDigitalApi.Repositories;
using LibreriaDigitalApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de repositorios
builder.Services.AddScoped<IBookRepository, BookRepository>();

// ... (lo que ya tienes de SQLite arriba)
// 1. Configurar la conexión a la base de datos SQLite
builder.Services.AddDbContext<LibreriaDigitalApi.Data.AppDbContext>(options =>
    options.UseSqlite("Data Source=LibreriaDigital.db"));

// 2. Registrar el Repositorio (Esto cumple con el Requisito Técnico #3)
builder.Services.AddScoped<LibreriaDigitalApi.Repositories.IBookRepository, LibreriaDigitalApi.Repositories.BookRepository>();
builder.Services.AddControllers(); // PASO A: Asegúrate que esta línea esté
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapControllers();
// PASO B: Agrega esta línea justo aquí abajo

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
using (var scope = app.Services.CreateScope()) { scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated(); }
app.Run();