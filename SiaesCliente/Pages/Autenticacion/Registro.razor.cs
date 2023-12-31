using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using System.Text.RegularExpressions;


namespace SiaesCliente.Pages.Autenticacion
{
    public partial class Registro
    {

        private Usuario usuarioParaRegistro = new Usuario();
        public bool EstaProcesando { get; set; } = false;
        public bool MostrarErroresRegistro { get; set; }

        public IEnumerable<string> Errores { get; set; }

        [Inject]
        public IServicioAutenticacion servicioAutenticacion { get; set; } 

        [Inject]
        public NavigationManager navigationManager { get; set; }


        private async Task RegistrarUsuario()
        {
            MostrarErroresRegistro = false;
            EstaProcesando = true;

            usuarioParaRegistro.NombreUsuario = LimpiarYPrevenirInyeccion(usuarioParaRegistro.NombreUsuario);
            usuarioParaRegistro.Nombre = LimpiarYPrevenirInyeccion(usuarioParaRegistro.Nombre);
            usuarioParaRegistro.Apellidos = LimpiarYPrevenirInyeccion(usuarioParaRegistro.Apellidos);

            var result = await servicioAutenticacion.RegistrarUsuario(usuarioParaRegistro);
            if (result.registroCorrecto)
            {
                EstaProcesando = false;
                navigationManager.NavigateTo("/registrar-usuario");
            }
            else
            {
                EstaProcesando = false;
                Errores = result.Errores!;
                MostrarErroresRegistro = true;
            }
        }

        private string LimpiarYPrevenirInyeccion(string valor)
        {
            // Limpiar espacios en blanco, convertir a minúsculas y prevenir inyección de código malicioso
            if (!string.IsNullOrEmpty(valor))
            {
                valor = valor.Trim().ToLower();
                valor = Regex.Replace(valor, "<.*?>", String.Empty);
            }
            return valor;
        }



    }

}
