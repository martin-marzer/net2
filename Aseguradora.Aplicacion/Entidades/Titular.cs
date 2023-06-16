namespace Aseguradora.Aplicacion.Entidades;

public class Titular : Persona{ 
    public string Direccion {get; set;} = "Sin direccion";
    public string Email {get; set;} = "Sin email";
    public List<Vehiculo>? listaVehiculos {get; set;} //Se guardan los vehiculos pertenecientes al titular


    public Titular(int dni, string? apellido, string? nombre, string? telefono, string? direccion, string?email) : base(dni,apellido,nombre, telefono){
        if(!string.IsNullOrWhiteSpace(direccion)) Direccion = direccion;
        if(!string.IsNullOrWhiteSpace(email)) Email = email;
    }

    public override string ToString(){
        return $"{base.ToString()} {Direccion} {Email}";
    }

}