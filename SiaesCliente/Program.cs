
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SiaesCliente;
using SiaesCliente.Servicios;
using SiaesLibraryShared.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Agregar Servicios aquí
builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();


//Para usar el LocalStorage
builder.Services.AddBlazoredLocalStorage();


//Agregar para la autenticacion y autorizacion
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
await builder.Build().RunAsync();
