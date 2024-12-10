namespace API.Models;

public class Tarefa
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.Now; 
}