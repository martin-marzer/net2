using Aseguradora.Aplicacion.Entidades;
using Aseguradora.Aplicacion.Interfaces;

namespace Aseguradora.Aplicacion.UseCases;

public class ObtenerTitularUseCase  : TitularUseCase 
{
    public ObtenerTitularUseCase(IRepositorioTitular repo): base(repo)
    {
    }
    public Titular? Ejecutar(int ID)
    {
        return Repositorio.ObtenerTitular(ID);
    }
}
