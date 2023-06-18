using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Aseguradora.UI.Data;

//agrego mis usings
using Aseguradora.Repositorios;
using Aseguradora.Aplicacion.UseCases;
using Aseguradora.Aplicacion.Interfaces;


using (var db = new AseguradoraContext())
{
    db.Database.EnsureCreated();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//agrego mis servicios
builder.Services.AddTransient<AgregarTitularUseCase>();
builder.Services.AddTransient<ListarTitularesUseCase>();
builder.Services.AddTransient<EliminarTitularUseCase>();
builder.Services.AddTransient<ModificarTitularUseCase>();
builder.Services.AddScoped<IRepositorioTitular, RepositorioTitular>();

builder.Services.AddTransient<AgregarVehiculoUseCase>();
builder.Services.AddTransient<ListarVehiculosUseCase>();
builder.Services.AddTransient<EliminarVehiculoUseCase>();
builder.Services.AddTransient<ModificarVehiculoUseCase>();
builder.Services.AddScoped<IRepositorioVehiculo, RepositorioVehiculo>();

builder.Services.AddTransient<AgregarPolizaUseCase>();
builder.Services.AddTransient<ListarPolizasUseCase>();
builder.Services.AddTransient<EliminarPolizaUseCase>();
builder.Services.AddTransient<ModificarPolizaUseCase>();
builder.Services.AddScoped<IRepositorioPoliza, RepositorioPoliza>();

builder.Services.AddTransient<AgregarSiniestroUseCase>();
builder.Services.AddTransient<ListarSiniestrosUseCase>();
builder.Services.AddTransient<EliminarSiniestroUseCase>();
builder.Services.AddTransient<ModificarSiniestroUseCase>();
builder.Services.AddScoped<IRepositorioSiniestro, RepositorioSiniestro>();

builder.Services.AddTransient<AgregarTerceroUseCase>();
builder.Services.AddTransient<ListarTercerosUseCase>();
builder.Services.AddTransient<EliminarTerceroUseCase>();
builder.Services.AddTransient<ModificarTerceroUseCase>();
builder.Services.AddScoped<IRepositorioTercero, RepositorioTercero>();



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




/*
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

*/