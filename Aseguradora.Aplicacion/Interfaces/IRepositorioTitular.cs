using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Aplicacion.Interfaces;

public interface IRepositorioTitular{

    Titular? ObtenerTitular(int ID);
    void AgregarTitular(Titular titular);
    void ModificarTitular(Titular titular);
    void EliminarTitular(int ID);
    List<Titular> ListarTitulares();
    List<Vehiculo> ListarVehiculosDelTitular(int ID);
}