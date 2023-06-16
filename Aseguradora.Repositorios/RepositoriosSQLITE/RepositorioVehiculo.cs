using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;


namespace Aseguradora.Repositorios;

public class RepositorioVehiculo : IRepositorioVehiculo
{    
    public void AgregarVehiculo(Vehiculo? vehiculo)
    {
        if (vehiculo == null) throw new Exception("error: no se puede cargar vehiculo");
        using (var context = new AseguradoraContext())
        {
            if (!context.Titulares.Any(t => t.ID == vehiculo.TitularId)) throw new Exception("error: el id del titular q ingresaste no existe");
            context.Add(vehiculo);
            context.SaveChanges();
        }
    }

    //previamente liste los Vehiculos busque uno y lo modifico aca
    public void ModificarVehiculo(Vehiculo? vehiculoModificado)
    {    
        if (vehiculoModificado == null) throw new Exception("error: tenes que cargar el vehiculo previamente");
        using (var context = new AseguradoraContext())
        {
            var vehiculoEncontrado = context.Vehiculos.FirstOrDefault(v => v.ID == vehiculoModificado.ID);
            if (vehiculoEncontrado == null) throw new Exception("lo siento compadre, no existe ese vehiculo, intenta de nuevo ");
            
            if(!context.Titulares.Any(t => t.ID == vehiculoModificado.TitularId)) throw new Exception("el id del titular no es valido, intenta de nuevo ");

            vehiculoEncontrado.Dominio = vehiculoModificado.Dominio;
            vehiculoEncontrado.Marca = vehiculoModificado.Marca;
            vehiculoEncontrado.TitularId = vehiculoModificado.TitularId;

            // vehiculoEncontrado.Dominio = "patente1";
            // vehiculoEncontrado.Marca = "mustang";
            // vehiculoEncontrado.TitularId = 1;
            context.SaveChanges();
        }
    }




    //tengo q ver esto de modificar en cascada
    public void EliminarVehiculo(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var vehiculoElim = context.Vehiculos.FirstOrDefault(v => v.ID == ID);
            if (vehiculoElim == null) throw new Exception("lo siento compadre, no existe el vehiculo con ese ID, intenta de nuevo ");
            
            context.RemoveRange(vehiculoElim);
            context.SaveChanges();
        }
    }


    public List<Vehiculo> ListarVehiculos()
    {
        using (var context = new AseguradoraContext())
        {
            var listaVehiculos = context.Vehiculos.ToList();
            return listaVehiculos;
        }
    }

}