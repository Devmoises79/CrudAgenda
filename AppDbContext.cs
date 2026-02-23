using Microsoft.EntityFrameworkCore;
using AgendaContatos.Models;

namespace AgendaContatos.Data;

public class AppDbContext : DbContext
{
    public DbSet<Contato> Contatos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=agenda.db");
    }
}