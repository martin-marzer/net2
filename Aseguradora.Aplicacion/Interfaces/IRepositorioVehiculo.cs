using Aseguradora.Aplicacion.Entidades;
namespace Aseguradora.Aplicacion.Interfaces;

public interface IRepositorioVehiculo
{
    Vehiculo? ObtenerVehiculo(int ID);
    void AgregarVehiculo(Vehiculo vehiculo);
    void ModificarVehiculo(Vehiculo vehiculo);
    void EliminarVehiculo(int id);
    List<Vehiculo> ListarVehiculos();
    List<Poliza> ListarPolizasDeVehiculo(int ID);
}