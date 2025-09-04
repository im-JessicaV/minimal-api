using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dominio.Interfaces;
using MinimalAPI.Dominio.ModelViews;
using MinimalAPI.Dominio.Servicos;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dbContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql")));
});
var app = builder.Build();


app.MapGet("/", () => Results.Json(new Home()));

app.MapPost("/login", ([FromBody] loginDTO loginDTO, IAdministradorServico administradorServico) =>
{
    var administrador = administradorServico.Login(loginDTO);
    if (administradorServico.Login(loginDTO) != null)
    {
        return Results.Ok("Login realizado com sucesso!!");
    }

    return Results.Unauthorized();
});

app.UseSwagger();
app.UseSwaggerUI();
app.Run();
