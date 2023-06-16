namespace Aseguradora.Aplicacion.Entidades;

public class Vehiculo
{
    public int ID {get; private set;} 
    public string Dominio {get;set;} = "Sin dominio";
    public string Marca {get;set;} = "Sin marca";
    public int AnioFabricacion {get;set;} = 1990;
    public int TitularId {get;set;}


    
    public Vehiculo(string? dominio, string? marca, int anioFabricacion, int titularId)
    {
        if (titularId < 1) throw new Exception("los titulares son identificados a partir del id 1");
        TitularId = titularId;

        if (anioFabricacion >= 1990 && anioFabricacion <= DateTime.Now.Year) AnioFabricacion = anioFabricacion;
        if(!string.IsNullOrWhiteSpace(dominio)) Dominio = dominio;
        if(!string.IsNullOrWhiteSpace(marca)) Marca = marca;
    }

    public override string ToString()
    {
        return $"ID del vehiculo {ID}, Año Fabricacion {AnioFabricacion}, Marca {Marca}, Dominio {Dominio}, ID del titular {TitularId} ";
    }
}