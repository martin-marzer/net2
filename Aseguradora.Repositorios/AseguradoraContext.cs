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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //con esto le obligo a que no se repitan los dni, en caso de q ocurra me tira una expecion
        modelBuilder.Entity<Titular>()
            .HasIndex(t => t.Dni)
            .IsUnique();

        modelBuilder.Entity<Tercero>()
            .HasIndex(t => t.Dni)
            .IsUnique();

        //dominios unicos (patentes), si se repite hay excepcion
        modelBuilder.Entity<Vehiculo>()
            .HasIndex(v => v.Dominio)
            .IsUnique();

        //la relacion de cada vehiculo con el titular la hace automaticamente (no se xq) ( es xq vehiculo tiene TitularId y titular tiene una lista de vehiculos)

        modelBuilder.Entity<Vehiculo>()
            .HasOne<Titular>()
            .WithMany(t => t.listaVehiculos)
            .HasForeignKey(v => v.TitularId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Poliza>()
            .HasOne<Vehiculo>()
            .WithOne()
            .HasForeignKey<Poliza>(p => p.VehiculoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Siniestro>()
            .HasOne<Poliza>()
            .WithMany()
            .HasForeignKey(s => s.PolizaId)
            .OnDelete(DeleteBehavior.Cascade);


        //un siniestro puede tener varios terceros (distintos) y un tercero solo esta involucrado en un siniestro

        modelBuilder.Entity<Tercero>()
            .HasOne<Siniestro>()
            .WithMany()
            .HasForeignKey(t => t.SiniestroId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}