using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using System.Text.RegularExpressions;
using System.Web;

namespace SiaesCliente.Pages.Autenticacion
{
    public  partial  class Acceder
    {
        private UsuarioAutenticacion usuarioAutenticacion = new UsuarioAutenticacion();
        public bool EstaProcesando { get; set; } = false;
        public bool MostrarErroresAutenticacion { get; set; }

        public string UrlRetorno { get; set; }

        public string Errores { get; set; }

     

        [Inject]
        public IServicioAutenticacion servicioAutenticacion { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        private ILocalStorageService _localStorage { get; set; }
        private async Task AccesoUsuario()
        {
            MostrarErroresAutenticacion = false;
            EstaProcesando = true;

            var result = await servicioAutenticacion.Acceder(usuarioAutenticacion);

            if (result.IsSuccess)
            {

                
                EstaProcesando = false;
                var urlAbsoluta = new Uri(navigationManager.Uri);
                var parametroQuery = HttpUtility.ParseQueryString(urlAbsoluta.Query);
                UrlRetorno = parametroQuery["returnUrl"];
                var perfil = result.Usuario?.Perfil;
                var nombreUsuario = result.Usuario?.Nombre;
                var unidad = result.Usuario?.CodEstablecimiento;
                await _localStorage.SetItemAsync("perfil", perfil);
                await _localStorage.SetItemAsync("nombreUsuario", nombreUsuario);
                await _localStorage.SetItemAsync("unidad", unidad);

                if (string.IsNullOrEmpty(UrlRetorno))
                {
                    navigationManager.NavigateTo("/inicio");
                }
                else
                {
                    navigationManager.NavigateTo("/" + UrlRetorno);
                }
               

            }
            else
            {
                EstaProcesando = false;
                MostrarErroresAutenticacion = true;
                Errores = "Usuario y/o contraseña incorrecto";
                navigationManager.NavigateTo("/acceder");
            }
        }

        private string LimpiarYPrevenirInyeccion(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                valor = valor.Trim().ToLower();
                valor = Regex.Replace(valor, "<.*?>", String.Empty); // Elimina etiquetas HTML maliciosas
                valor = valor.Replace("*", ""); // Excluye el carácter '*' de la eliminación
            }
            return valor;
        }

    }
}
