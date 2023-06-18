namespace Aseguradora.Aplicacion.Entidades;

using System.ComponentModel.DataAnnotations;

public abstract class Persona{
    public int ID{get; private set;}

    [Required(ErrorMessage = "el dni es obligatorio")]
    [RegularExpression(@"^(?!0)\d{1,8}$", ErrorMessage = "El número debe como maximo 8 digitos y ser positivo. (Dni Argentino)")]
    public int Dni{get; set;} 

    [Required(ErrorMessage = "el apellido es obligatorio")]
    public string? Apellido{get; set;}

    [Required(ErrorMessage = "el nombre es obligatorio")]
    public string? Nombre{get; set;}

    [Required(ErrorMessage = "el telefono es obligatorio")]
    public string? Telefono {get; set;}

    public Persona(){}
    
    public override string ToString(){
        return $"{ID}: {Dni} {Apellido} {Nombre} {Telefono}";
    }
}