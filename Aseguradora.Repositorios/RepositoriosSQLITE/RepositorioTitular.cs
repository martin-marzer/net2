using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Aseguradora.Repositorios;

public class RepositorioTitular : IRepositorioTitular
{    
    public Titular? ObtenerTitular(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var titular = context.Titulares.SingleOrDefault(t => t.ID == ID);
            return titular;
        }
    }
    public void AgregarTitular(Titular titular)
    {
        using (var context = new AseguradoraContext())
        {
            if (context.Titulares.Any(t => t.Dni == titular.Dni)) throw new Exception("error: probablemente ya existe ese titular");
            context.Add(titular);
            context.SaveChanges();
        }
    }

    //previamente liste los Titulars busque uno y lo modifico aca
    public void ModificarTitular(Titular titularModificado)
    {    
        using (var context = new AseguradoraContext())
        {
            var titularEncontrado = context.Titulares.SingleOrDefault(t => t.ID == titularModificado.ID);
            if (titularEncontrado == null) throw new Exception("lo siento compadre, no existe ese titular, intenta de nuevo ");
            
            if (titularEncontrado.Dni != titularModificado.Dni){
                if (context.Titulares.Any(t => t.Dni == titularModificado.Dni)) throw new Exception("error: probablemente ya existe ese titular");
            }
            
            titularEncontrado.Dni = titularModificado.Dni;
            titularEncontrado.Apellido = titularModificado.Apellido;
            titularEncontrado.Nombre = titularModificado.Nombre;
            titularEncontrado.Direccion = titularModificado.Direccion;
            titularEncontrado.Telefono = titularModificado.Telefono;
            titularEncontrado.Email = titularModificado.Email;
            context.SaveChanges();
        }
    }

    public void EliminarTitular(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var titularElim = context.Titulares.SingleOrDefault(t => t.ID == ID);
            if (titularElim == null) throw new Exception("lo siento compadre, no existe ese titular, intenta de nuevo ");
            context.Remove(titularElim);
            context.SaveChanges();  
        }
    }


    public List<Titular> ListarTitulares()
    {
        using (var context = new AseguradoraContext())
        {
            return context.Titulares.Include(t => t.Vehiculos).ToList();
        }
    }

    public  List<Vehiculo> ListarVehiculosDelTitular(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var listarConSusVehiculos = context.Titulares.First(t => t.ID == ID).Vehiculos;
            return listarConSusVehiculos;
        }
    }
}