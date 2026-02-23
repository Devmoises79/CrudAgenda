using Microsoft.EntityFrameworkCore;
using AgendaContatos.Models;

namespace AgendaContatos.Data;

public class AppDbContext : DbContext
{
    public DbSet<Contato> Contatos { get; set; }

    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=agenda.db");
        }
    }
}