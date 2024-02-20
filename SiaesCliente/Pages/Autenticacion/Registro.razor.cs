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

            var usuarioParaRegistroAPI = new UsuarioParaRegistroAPI
            {
                nombreUsuario = usuarioParaRegistro.NombreUsuario,
                nombre = usuarioParaRegistro.Nombre,
                apellidos = usuarioParaRegistro.Apellidos,
                correo = usuarioParaRegistro.Correo,
                codEstablecimiento = usuarioParaRegistro.CodEstablecimiento,
                clave = usuarioParaRegistro.Clave,
                perfil = usuarioParaRegistro.Perfil,
                estado = usuarioParaRegistro.Estado,
                fechaCaducidad = usuarioParaRegistro.FechaCaducidad,
                usuarioCreacion = usuarioParaRegistro.NombreUsuario,
                fechaCreacion = (DateTime)usuarioParaRegistro.FechaCreacion
            };



            var result = await servicioAutenticacion.RegistrarUsuarioAPI(usuarioParaRegistroAPI);
            if (result.registroCorrecto)
            {
                EstaProcesando = false;
                navigationManager.NavigateTo("/acceder");
         
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
