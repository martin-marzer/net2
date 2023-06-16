/*
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Aseguradora.UI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

*/

using Aseguradora.Repositorios;
using Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Entidades;

// Poliza a = new Poliza(2,33,"hola","as",null,null);
using (var db = new AseguradoraContext())
{
    db.Database.EnsureCreated();
}

var repoTitular = new RepositorioTitular();
var repoVehiculo = new RepositorioVehiculo();

var agregarTitularUseCase = new AgregarTitularUseCase(repoTitular);
var eliminarTitularUseCase = new EliminarTitularUseCase(repoTitular);
var modificarTitularUseCase = new ModificarTitularUseCase(repoTitular);
var listarTitularesUseCase = new ListarTitularesUseCase(repoTitular);

var agregarVehiculoUseCase = new AgregarVehiculoUseCase(repoVehiculo);
var eliminarVehiculoUseCase = new EliminarVehiculoUseCase(repoVehiculo);
var modificarVehiculoUseCase = new ModificarVehiculoUseCase(repoVehiculo);
var listarVehiculosUseCase = new ListarVehiculosUseCase(repoVehiculo);


agregarTitularUseCase.Ejecutar(new Titular(39,"morales","miles", "22412","arriba de esta", "negro@92.hotmail.com"));
agregarTitularUseCase.Ejecutar(new Titular(58, null,null,null,null,null));


// var lista = listarTitularesUseCase.Ejecutar();

// var titular = lista.Find(t => t.ID == 1);
// if (titular != null) eliminarTitularUseCase.Ejecutar(titular.ID);

// titular = lista.Find(t => t.ID == 2);
// if (titular != null) modificarTitularUseCase.Ejecutar(titular);

agregarVehiculoUseCase.Ejecutar(new Vehiculo("patentePrueba","ferrari", 1800,1));
agregarVehiculoUseCase.Ejecutar(new Vehiculo("otra patente","ferrari", 2010,2));

var lista = listarTitularesUseCase.Ejecutar();
var titular = lista.Find(t => t.ID == 1);
if (titular != null) eliminarTitularUseCase.Ejecutar(titular.ID);


// var lista = listarVehiculosUseCase.Ejecutar();

// var vehiculo = lista.Find(v => v.ID == 1);
// if (vehiculo != null) eliminarVehiculoUseCase.Ejecutar(vehiculo.ID);

// vehiculo = lista.Find(v => v.ID == 2);
// if (vehiculo != null) modificarVehiculoUseCase.Ejecutar(vehiculo);

