using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;


namespace SiaesCliente.Pages.Autenticacion
{
    public partial class Registro
    {

        private UsuarioRegistro usuarioParaRegistro = new UsuarioRegistro();
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
            var result = await servicioAutenticacion.RegistrarUsuario(usuarioParaRegistro);
            if (result.registroCorrecto)
            {
                EstaProcesando = false;
                navigationManager.NavigateTo("/RegistroUsuariosInforme");
            }
            else
            {
                EstaProcesando = false;
                Errores = result.Errores!;
                MostrarErroresRegistro = true;
            }
        }

    }

}
