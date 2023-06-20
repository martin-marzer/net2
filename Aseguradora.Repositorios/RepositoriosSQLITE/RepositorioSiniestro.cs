using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

using  System.Globalization;

namespace Aseguradora.Repositorios;

public class RepositorioSiniestro : IRepositorioSiniestro
{       
    public void AgregarSiniestro(Siniestro siniestro)
    {
        using (var context = new AseguradoraContext())
        {
            var poliza = context.Polizas.FirstOrDefault(p => p.ID == siniestro.PolizaId);
            if (poliza == null) throw new Exception("lo siento compadre, no existe ese id de poliza, intenta de nuevo ");

            if (poliza.FechaDeFinDeVigencia < siniestro.FechaDeOcurrencia) throw new Exception($"no podes registrar el siniestro de la fecha {siniestro.FechaDeOcurrencia}  porque tu seguro ya vencio {poliza.FechaDeFinDeVigencia}");
            
            context.Add(siniestro);
            context.SaveChanges();
        }
    }

    //previamente liste los Siniestros busque uno y lo modifico aca
    public void ModificarSiniestro(Siniestro siniestroModificado)
    {    
        using (var context = new AseguradoraContext())
        {
            var siniestroEncontrado = context.Siniestros.FirstOrDefault(s => s.ID == siniestroModificado.ID);
            if (siniestroEncontrado == null) throw new Exception("lo siento compadre, no existe ese siniestro, intenta de nuevo ");
            
            if(!context.Polizas.Any(v => v.ID == siniestroModificado.PolizaId)) throw new Exception("el id de la poliza no es valido, intenta de nuevo ");

            siniestroEncontrado.DireccionDelHecho =  siniestroModificado.DireccionDelHecho;
            siniestroEncontrado.DescripcionDelAccidente = siniestroModificado.DescripcionDelAccidente;
            siniestroEncontrado.FechaDeingreso = siniestroModificado.FechaDeingreso;
            siniestroEncontrado.FechaDeOcurrencia = siniestroModificado.FechaDeOcurrencia;
            siniestroEncontrado.PolizaId = siniestroModificado.PolizaId;

            context.SaveChanges();
        }
    }



    //tengo q ver esto de modificar en cascada
    public void EliminarSiniestro(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var siniestro = context.Siniestros.FirstOrDefault(s => s.ID == ID);
            if (siniestro == null) throw new Exception("lo siento compadre, no existe el siniestro con ese ID, intenta de nuevo ");
            
            context.Remove(siniestro);
            context.SaveChanges();
        }
    }

    public List<Siniestro> ListarSiniestros()
    {
        using (var context = new AseguradoraContext())
        {
            var listaSiniestros = context.Siniestros.ToList();
            return listaSiniestros;
        }
        
    }

    public List<Tercero> ListarTercerosDeSiniestro(int ID)
    {
        using (var context = new AseguradoraContext())
        {
            var listarConSusTerceros = context.Siniestros.First(t => t.ID == ID).Terceros;
            return listarConSusTerceros;
        }
    }
}           