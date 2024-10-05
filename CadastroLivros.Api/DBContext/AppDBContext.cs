using CadastroLivros.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace CadastroLivros.Api.DBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {

    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Assunto> Assuntos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Livro>()
            .HasMany(l => l.Autores)
            .WithMany(a => a.Livros);

        modelBuilder.Entity<Livro>()
            .HasMany(l => l.Assuntos)
            .WithMany(a => a.Livros);
    }
}