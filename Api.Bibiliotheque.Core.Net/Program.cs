using Api.Bibiliotheque.Core.Net.Configuration;
using Api.Bibiliotheque.Core.Net.Interfaces;
using Api.Bibiliotheque.Core.Net.Models;
using Api.Bibiliotheque.Core.Net.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//�tape : 3 On cr�e le fichier de configuration //Toutes les configuration vont �tre cherch� � partir de fichier appsettings.json
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


//�tape : 2
//Configuration du logger / Cr�ation du logger
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();


//�tape : 1
//Ajout l'utilisation de Serilog
builder.Host.UseSerilog();



// Add services to the container.
builder.Services.AddDbContext<BibliothequeContext>(opt => opt.UseInMemoryDatabase("MyDatabase"));

//Ajout service d'authentification qu'on a cr�e dans le fichier ServiceConfiguration
builder.Services.AddAuthentificationService();

//Dependency injection de nos services m�tiers
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllersService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Utilisation de service d'authentification
//il faut qu'il soit avant UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
