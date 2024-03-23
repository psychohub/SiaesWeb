using Microsoft.AspNetCore.Components;
using SiaesCliente.Servicios;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;



namespace SiaesCliente.Pages.Autenticacion
{
    public partial class AsociarUsuario : ComponentBase
    {


        private Usuario usuarioParaRegistro = new Usuario();
        public bool EstaProcesando { get; set; } = false;
        public bool MostrarErroresRegistro { get; set; }

        public IEnumerable<string> Errores { get; set; }
        [Inject]
        public IServicioBitacora ServicioBitacora { get; set; }

        [Inject]
        public IServicioUsuarioRepositorio servicioUsuarioRepositorio { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }
        private AsociarUsuarioModel asociarUsuarioModel = new AsociarUsuarioModel();
        private List<Rol> roles = new List<Rol>();
        private List<SubArea> subAreas = new List<SubArea>();

        protected override async Task OnInitializedAsync()
        {
            roles = (await servicioUsuarioRepositorio.GetRoles()).ToList();
            subAreas = (await servicioUsuarioRepositorio.GetSubAreas()).ToList();
        }

        public async Task GuardarAsociacion()
        {
            try
            {
                // Verificar si el usuario existe
                var usuario = await servicioUsuarioRepositorio.GetUsuarioByNombreUsuario(asociarUsuarioModel.NombreUsuario);
            if (usuario == null)
            {
                // Mostrar mensaje de que el usuario no existe
                Errores = new List<string> { "El usuario no existe" };
                MostrarErroresRegistro = true;
                return;
            }

            // Actualizar las propiedades del usuario
            usuario.IdRol = asociarUsuarioModel.IdRol;
            usuario.IdSubArea = asociarUsuarioModel.IdSubArea;

            // Llamar al método para actualizar el usuario
            var response = await servicioUsuarioRepositorio.ActualizarUsuario(usuario);
            if (response.Exitoso)
            {
                EstaProcesando = false;
                LimpiarFormulario();

            }
            else
            {
                // Mostrar los errores
                Errores = response.Errores;
                MostrarErroresRegistro = true;

            }
            }
            catch (Exception ex)
            {
                // Capturar y manejar la excepción
                MostrarErroresRegistro = true;
            }
        }

        public class AsociarUsuarioModel
        {
            public string NombreUsuario { get; set; } = string.Empty;
            public int IdRol { get; set; }
            public int IdSubArea { get; set; }
        }

        private void LimpiarFormulario()
        {
            // Limpiar el InputText "nombreUsuario"
            asociarUsuarioModel.NombreUsuario = string.Empty;

            // Restablecer los InputSelect "rol" y "subArea" a la opción predeterminada
            asociarUsuarioModel.IdRol = 0;
            asociarUsuarioModel.IdSubArea = 0;
        }


    }
}
