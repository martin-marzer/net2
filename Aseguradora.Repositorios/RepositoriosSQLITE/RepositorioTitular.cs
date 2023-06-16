using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Aseguradora.Repositorios;

public class RepositorioTitular : IRepositorioTitular
{    
    public void AgregarTitular(Titular? titular)
    {
        if (titular == null) throw new Exception("error: no se puede cargar titular");
        using (var context = new AseguradoraContext())
        {
            context.Add(titular);
            context.SaveChanges();
        }
    }

    //previamente liste los Titulars busque uno y lo modifico aca
    public void ModificarTitular(Titular? titularModificado)
    {    
        if (titularModificado == null) throw new Exception("error: tenes que cargar el titular previamente");
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
            // titularEncontrado.Dni = 100;
            // titularEncontrado.Apellido = "vazqe";
            // titularEncontrado.Nombre = "martin";
            // titularEncontrado.Telefono = "22412asd";
            // titularEncontrado.Email = "email@.com";
            context.SaveChanges();
        }
    }

    public void EliminarTitular(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var titularElim = context.Titulares.FirstOrDefault(t => t.ID == ID);
            if (titularElim == null) throw new Exception("lo siento compadre, no existe el titular con ese ID, intenta de nuevo ");
            
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

    public  List<Titular> ListarTitularesConSusVehiculos()
    {
        using (var context = new AseguradoraContext())
        {
            var listaTitulares = context.Titulares.Include(t => t.listaVehiculos).ToList();
            return listaTitulares;
        }
    }
}