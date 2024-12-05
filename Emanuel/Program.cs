using Emanuel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{
    return Results.Ok(ctx.Funcionarios.ToList());
});


app.MapPost("/api/folha/cadastrar",([FromBody] Folha folha,
[FromServices] AppDataContext ctx) =>
{
    Funcionario? funcionario =
    ctx.Funcionarios.Find(folha.FuncionarioId);

    if(funcionario is null)
    return Results.NotFound("Funcionario nao encontrado");

    folha.Funcionario = funcionario;



});






















app.Run();
