using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Detencion> Detenciones {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=detenciones.db");

    }
}