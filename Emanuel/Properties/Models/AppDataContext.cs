using Microsoft.EntityFrameworkCore;

namespace Emanuel.Models;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=emanuel_emanuel.db");
    }
}