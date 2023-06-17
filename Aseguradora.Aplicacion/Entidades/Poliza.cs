namespace Aseguradora.Aplicacion.Entidades;
public class Poliza
{
    public int ID {get; private set;}
    public double ValorAsegurado {get;set;} = 0;
    public string Franquicia {get;set;} = "No tiene franquicia";
    public string TipoDeCobertura {get;set;}="No tiene tipo de cobertura";
    public DateTime FechaDeInicioDeVigencia {get;set;} = DateTime.Now;
    public DateTime FechaDeFinDeVigencia {get;set;} = DateTime.Now.AddYears(1); 
    public int VehiculoId {get;set;}

    public List<Siniestro>? listaSiniestros {get; set;}
    
    public Poliza(int vehiculoId, double valorAsegurado, String? franquicia,String? tipoDeCobertura, DateTime fechaDeInicioDeVigencia, DateTime fechaDeFinDeVigencia){
        if (vehiculoId < 1) throw new Exception("los vehiculos son identificados a partir del id 1");
        VehiculoId = vehiculoId;

        if (valorAsegurado > 0)  ValorAsegurado = valorAsegurado;;
        if(!string.IsNullOrWhiteSpace(franquicia)) Franquicia = franquicia;
        if(!string.IsNullOrWhiteSpace(franquicia)) Franquicia = franquicia;
        if(fechaDeInicioDeVigencia != null)  FechaDeInicioDeVigencia = (DateTime)fechaDeInicioDeVigencia;
        if(fechaDeFinDeVigencia != null &&  fechaDeFinDeVigencia > FechaDeInicioDeVigencia )  FechaDeFinDeVigencia = (DateTime)fechaDeFinDeVigencia; //prestar atencion a mayusculas

        if(!string.IsNullOrWhiteSpace(tipoDeCobertura)) {
            tipoDeCobertura = tipoDeCobertura.ToUpper();
            if(tipoDeCobertura == "RESPONSABILIDAD  CIVIL" || tipoDeCobertura == "TODO RIESGO") Franquicia = tipoDeCobertura;
        }
        
    }

    public override String ToString(){
        return $"ID: {ID}, VehiculoId: {VehiculoId}, valorAsegurado: {ValorAsegurado}, franquicia: {Franquicia}, tipoDeCobertura: {TipoDeCobertura}, fechaDeInicioDeVigencia: {FechaDeInicioDeVigencia}, fechaDeFinDeVigencia: {FechaDeFinDeVigencia}";
    }
}