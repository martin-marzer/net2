using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;


namespace Aseguradora.Repositorios;

public class RepositorioPoliza : IRepositorioPoliza
{    
    public void AgregarPoliza(Poliza? poliza)
    {
        if (poliza == null) throw new Exception("error: no se puede cargar poliza");
        using (var context = new AseguradoraContext())
        {
            if (!context.Vehiculos.Any(v => v.ID == poliza.VehiculoId)) throw new Exception("error: el id del vehiculo q ingresaste no existe");
            context.Add(poliza);
            context.SaveChanges();
        }
    }

    //previamente liste los Polizas busque uno y lo modifico aca
    public void ModificarPoliza(Poliza? polizaModificado)
    {    
        if (polizaModificado == null) throw new Exception("error: tenes que cargar la poliza previamente");
        using (var context = new AseguradoraContext())
        {
            var polizaEncontrada = context.Polizas.FirstOrDefault(p => p.ID == polizaModificado.ID);
            if (polizaEncontrada == null) throw new Exception("lo siento compadre, no existe ese poliza, intenta de nuevo ");
            
            if(!context.Vehiculos.Any(v => v.ID == polizaModificado.VehiculoId)) throw new Exception("el id del vehiculo no es valido, intenta de nuevo ");

            polizaEncontrada.ValorAsegurado = polizaModificado.ValorAsegurado;
            polizaEncontrada.Franquicia = polizaModificado.Franquicia;
            polizaEncontrada.TipoDeCobertura = polizaModificado.TipoDeCobertura;
            polizaEncontrada.FechaDeInicioDeVigencia = polizaModificado.FechaDeInicioDeVigencia;
            polizaEncontrada.FechaDeFinDeVigencia = polizaModificado.FechaDeFinDeVigencia;
            polizaEncontrada.VehiculoId = polizaModificado.VehiculoId;
  
            context.SaveChanges();
        }
    }




    //tengo q ver esto de modificar en cascada
    public void EliminarPoliza(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var polizaElim = context.Polizas.FirstOrDefault(p => p.ID == ID);
            if (polizaElim == null) throw new Exception("lo siento compadre, no existe el poliza con ese ID, intenta de nuevo ");
            
            context.RemoveRange(polizaElim);
            context.SaveChanges();
        }
    }


    public List<Poliza> ListarPolizas()
    {
        using (var context = new AseguradoraContext())
        {
            var listaPolizas = context.Polizas.ToList();
            return listaPolizas;
        }
    }

}