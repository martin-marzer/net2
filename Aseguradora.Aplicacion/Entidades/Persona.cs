namespace Aseguradora.Aplicacion.Entidades;

public abstract class Persona{
    public int ID{get; private set;}
    public int Dni{get; set;} 
    public string Apellido{get; set;} = "Sin apellido";
    public string Nombre{get; set;} = "Sin nombre";
    public string Telefono {get; set;} = "Sin telefono";

    public Persona(int dni, string? apellido, string? nombre, string? telefono){
        if (dni < 0) throw new Exception("no puede ser un numero negativo");
        Dni = dni;

        if(!string.IsNullOrWhiteSpace(apellido))  Apellido = apellido;
        if(!string.IsNullOrWhiteSpace(nombre)) Nombre = nombre;
        if(!string.IsNullOrWhiteSpace(telefono)) Telefono = telefono;
    }

    public override string ToString(){
        return $"{ID}: {Dni} {Apellido} {Nombre} {Telefono}";
    }
}