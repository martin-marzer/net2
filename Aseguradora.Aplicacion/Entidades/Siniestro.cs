namespace Aseguradora.Aplicacion.Entidades;

public class Siniestro { 
    public int ID {get; private set;} //es privado porque solo se encarga de setearlo la BD, no se le puede dar un valor al objeto
    public string DireccionDelHecho {get; set;} = "No tiene direccion";
    public string DescripcionDelAccidente {get; set;} = "No tiene Desc";
    public DateTime FechaDeingreso {get;set;} = DateTime.Now;
    public DateTime FechaDeOcurrencia {get;set;} = DateTime.Now;
    public int PolizaId {get;set;}


  
    public Siniestro(int polizaId, String? direccionDelHecho, String? descripcionDelAccidente, DateTime fechaDeOcurrencia){
        if (polizaId < 1) throw new Exception("las polizas son identificadas a partir del id 1");
        PolizaId=polizaId;

        if(!string.IsNullOrWhiteSpace(direccionDelHecho)) DireccionDelHecho = direccionDelHecho;
        if(!string.IsNullOrWhiteSpace(descripcionDelAccidente)) DescripcionDelAccidente = descripcionDelAccidente;
        if(fechaDeOcurrencia != null)  FechaDeOcurrencia = (DateTime)fechaDeOcurrencia;
    }

    public override String ToString(){
        return $"ID: {ID}, PolizaId: {PolizaId}, DireccionDelHecho: {DireccionDelHecho}, DescripciónDelAccidente: {DescripcionDelAccidente}, FechaDeingreso: {FechaDeingreso}, FechaDeOcurrencia: {FechaDeOcurrencia}";
    }

}