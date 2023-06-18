namespace Aseguradora.Aplicacion.Entidades;

using System.ComponentModel.DataAnnotations;

public class Titular : Persona{ 
    [Required(ErrorMessage = "la direccion es obligatoria")]    
    public string? Direccion {get; set;}

    [Required(ErrorMessage = "el email es obligatorio")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Debes indicar un email válido")]
    public string? Email {get; set;}
    public List<Vehiculo> Vehiculos {get; set;} = new List<Vehiculo>(); //Se guardan los vehiculos pertenecientes al titular

    public Titular(){}

    public override string ToString(){
        return $"{base.ToString()} {Direccion} {Email}";
    }

}