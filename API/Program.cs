using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Coisas a fazer!");

app.MapPost("/api/tarefas/cadastrar", ([FromBody] Tarefa tarefa,  
    [FromServices] AppDataContext ctx) =>
{
    ctx.Tarefas.Add(tarefa);
    ctx.SaveChanges();
    return Results.Created("", tarefa);
});

app.MapPost("/api/tarefas/buscar/{id}", ([FromRoute] int id,
    [FromServices] AppDataContext ctx) =>
{
   Tarefa? tarefa = ctx.Tarefas.Find(id);
   if (tarefa is null)
   {
      return Results.NotFound();
   }

   return Results.Ok(tarefa);
});



app.MapGet("/api/tarefas/listar", ([FromServices] AppDataContext ctx) =>
{
   if (ctx.Tarefas.Any())
   {
     return Results.Ok(ctx.Tarefas.ToList());
   }
   return Results.NotFound();
});

app.MapDelete("/api/tarefas/deletar/{id}", ([FromRoute] int id,
    [FromServices] AppDataContext ctx) =>
{
   Tarefa? tarefa = ctx.Tarefas.Find(id);
   if (tarefa is null)
   {
      return Results.NotFound();
   }
   ctx.Tarefas.Remove(tarefa);
   ctx.SaveChanges();
   return Results.Ok(tarefa);
});



app.Run();
