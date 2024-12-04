using Emanuel.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Prova em dupla com consulta!");

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario,
 [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created($"/produto/{funcionario.Id}", funcionario);
});

app.Run();
