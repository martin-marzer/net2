using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion.Entidades;

namespace Aseguradora.Repositorios;
public class AseguradoraContext : DbContext
{
    #nullable disable
    public DbSet<Titular> Titulares { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }
    public DbSet<Tercero> Terceros { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Ruta personalizada donde deseas crear el archivo SQLite, x defecto se crea el archivo en el mismo lugar q ejecutas program.cs (Aseguradora.UI)
        string dbPath;
        string separador = Path.DirectorySeparatorChar.ToString();
        if(separador == @"\") dbPath = @"..\Aseguradora.Repositorios\Aseguradora.sqlite";
        else  dbPath = "../Aseguradora.Repositorios/Aseguradora.sqlite";

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder){}
}