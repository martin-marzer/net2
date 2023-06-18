using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Repositorios;

public class RepositorioTitular : IRepositorioTitular
{    
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
            var titularEncontrado = context.Titulares.FirstOrDefault(t => t.ID == titularModificado.ID);
            if (titularEncontrado == null) throw new Exception("lo siento compadre, no existe ese titular, intenta de nuevo ");

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
            var titularElim = context.Titulares.First(t => t.ID == ID);
            context.RemoveRange(titularElim);
            context.SaveChanges();        
        }
    }


    public List<Titular> ListarTitulares()
    {
        using (var context = new AseguradoraContext())
        {
            var listaTitulares = context.Titulares.ToList();
            return listaTitulares;
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