
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SiaesCliente;
using SiaesCliente.Helpers;
using SiaesCliente.Servicios;
using SiaesLibraryShared.Contracts;





var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Agregar Servicios aquí


builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();
builder.Services.AddScoped<IServicioUsuarioRepositorio, ServicioUsuarioRepositorio>();
builder.Services.AddScoped<IServicioIEMUsuarioInforme, ServicioIEMUsuarioInforme>();
builder.Services.AddScoped<IServicioBitacora, ServicioBitacoraCliente>();
builder.Services.AddScoped<IServicioActividadMacroRepositorio, ActividadMacroServicio>();
builder.Services.AddScoped<IServicioProcesoRepositorio, ProcesoServicio>();
builder.Services.AddScoped<IServicioSubProcesoRepositorio, SubProcesoServicio>();
builder.Services.AddScoped<IServicioTiempoInvertidoServicio, TiempoInvertidoServicio>();
builder.Services.AddScoped<IServicioTRegistroDiario, RegistroDiarioServicio>();
builder.Services.AddScoped<IServicioTUbicacion, TUbicacionService>();
builder.Services.AddScoped<IServicioDetalleProceso, ServicioDetalleProceso>();
builder.Services.AddScoped<IRegistroDiarioServicio, ObtenerRegistroDiarioServicio>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddBlazoredLocalStorage();
// Configurar BitacoraHelper
BitacoraHelper.ConfigurarServicioBitacora(builder.Services);
//Para usar el LocalStorage
builder.Services.AddBlazoredLocalStorage();



//Agregar para la autenticacion y autorizacion
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
await builder.Build().RunAsync();
