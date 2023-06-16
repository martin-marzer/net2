namespace Aseguradora.Aplicacion.Entidades;

public class Tercero : Persona{ 
    public string NombreAseguradora {get; set;} = "Sin nombre de Aseguradora";
    public int SiniestroId {get;set;}
    

    
    public Tercero(int dni, string? apellido, string? nombre, string? telefono, string? nombreAseguradora, int siniestroId) : base(dni,apellido,nombre,telefono){
        if (siniestroId < 1 ) throw new Exception("los siniestros son identificados a partir del id 1");
        SiniestroId = siniestroId;

        if(!string.IsNullOrWhiteSpace(nombreAseguradora)) NombreAseguradora = nombreAseguradora;
    }

    public override string ToString(){
        return $"{base.ToString()} {NombreAseguradora} {SiniestroId}";
    }

}