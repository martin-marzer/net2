using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;


namespace Aseguradora.Repositorios;

public class RepositorioTercero : IRepositorioTercero
{    
    public void AgregarTercero(Tercero tercero)
    {
        using (var context = new AseguradoraContext())
        {
            if (!context.Siniestros.Any(s => s.ID == tercero.SiniestroId)) throw new Exception("error: el id del Siniestro q ingresaste no existe");
            context.Add(tercero);
            context.SaveChanges();
        }
    }

    //previamente liste los Terceros busque uno y lo modifico aca
    public void ModificarTercero(Tercero terceroModificado)
    {    
        using (var context = new AseguradoraContext())
        {
            var terceroEncontrado = context.Terceros.FirstOrDefault(t => t.ID == terceroModificado.ID);
            if (terceroEncontrado == null) throw new Exception("lo siento compadre, no existe ese tercero, intenta de nuevo ");
            
            if(!context.Siniestros.Any(s => s.ID == terceroModificado.SiniestroId)) throw new Exception("el id del siniestro no es valido, intenta de nuevo ");

            terceroEncontrado.Dni = terceroModificado.Dni;
            terceroEncontrado.Apellido = terceroModificado.Apellido;
            terceroEncontrado.Nombre = terceroModificado.Nombre;
            terceroEncontrado.Telefono = terceroModificado.Telefono;
            terceroEncontrado.NombreAseguradora = terceroModificado.NombreAseguradora;
            terceroEncontrado.SiniestroId = terceroModificado.SiniestroId;
  
            context.SaveChanges();
        }
    }




    //tengo q ver esto de modificar en cascada
    public void EliminarTercero(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var terceroElim = context.Terceros.FirstOrDefault(t => t.ID == ID);
            if (terceroElim == null) throw new Exception("lo siento compadre, no existe el tercero con ese ID, intenta de nuevo ");
            
            context.Remove(terceroElim);
            context.SaveChanges();
        }
    }


    public List<Tercero> ListarTerceros()
    {
        using (var context = new AseguradoraContext())
        {
            var listaTerceros = context.Terceros.ToList();
            return listaTerceros;
        }
    }

}