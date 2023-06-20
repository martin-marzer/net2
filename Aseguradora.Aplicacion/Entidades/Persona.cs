namespace Aseguradora.Aplicacion.Entidades;

using System.ComponentModel.DataAnnotations;

public abstract class Persona{
    public int ID{get; private set;}

    [Required(ErrorMessage = "El DNI es obligatorio")]
    [RegularExpression(@"^(?!0)\d{1,8}$", ErrorMessage = "El número debe tener como maximo 8 digitos y ser positivo. (Dni Argentino)")]
    public string? Dni{get; set;} 

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Apellido debe tener 3 a 25 caracteres.")]
    public string? Apellido{get; set;}

    [Required(ErrorMessage = "el nombre es obligatorio")]
    [StringLength(25, MinimumLength = 3, ErrorMessage = "Nombre debe tener 3 a 25 caracteres.")]
    public string? Nombre{get; set;}

    [Required(ErrorMessage = "el telefono es obligatorio")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Ingrese un número de celular válido")]
    public string? Telefono {get; set;}

    public Persona(){}
    
    public override string ToString(){
        return $"{ID}: {Dni} {Apellido} {Nombre} {Telefono}";
    }
}