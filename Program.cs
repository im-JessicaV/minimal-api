using MinimalAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (loginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com.br" && loginDTO.Password == "123456")
    {
        return Results.Ok("Login com sucesso");
    }

    return Results.Unauthorized();
});

app.Run();
