using Microsoft.AspNetCore.Components;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;

namespace SiaesCliente.Pages.Autenticacion
{
    public class RegistroUsuarioInforme : ComponentBase
    {
        private string nombreUsuario = string.Empty;
        private int? codEstablecimiento;
        private List<string> informesDisponibles = new List<string>();
        private List<string> informesAsociados = new List<string>();

        [Inject] private IServicioIEMUsuarioInforme servicioIEMUsuarioInforme { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Cargar informes disponibles
            var informesDisponibles = await informeServicio.ObtenerInformesDisponibles();
            this.informesDisponibles = informesDisponibles.Select(i => i.DSC_INFORME).ToList();
        }

        private async Task CargarInformesAsociados()
        {
            if (!string.IsNullOrEmpty(nombreUsuario) && codEstablecimiento.HasValue)
            {
                // Cargar informes asociados al usuario y establecimiento
                var informesAsociados = await servicioIEMUsuarioInforme.ObtenerInformesAsociados(nombreUsuario, codEstablecimiento.Value);
                this.informesAsociados = informesAsociados.Select(i => i.DSC_INFORME).ToList();
            }
        }

        private async Task AsociarInformes(List<string> codigosInforme)
        {
            if (!string.IsNullOrEmpty(nombreUsuario) && codEstablecimiento.HasValue)
            {
                var resultado = await servicioIEMUsuarioInforme.AsociarInformes(nombreUsuario, codEstablecimiento.Value, codigosInforme);
                if (resultado)
                {
                    // Mostrar mensaje de éxito
                    await CargarInformesAsociados();
                }
                else
                {
                    // Mostrar mensaje de error
                }
            }
        }

        private async Task DesasociarInformes(List<string> codigosInforme)
        {
            if (!string.IsNullOrEmpty(nombreUsuario) && codEstablecimiento.HasValue)
            {
                var resultado = await servicioIEMUsuarioInforme.DesasociarInformes(nombreUsuario, codEstablecimiento.Value, codigosInforme);
                if (resultado)
                {
                    // Mostrar mensaje de éxito
                    await CargarInformesAsociados();
                }
                else
                {
                    // Mostrar mensaje de error
                }
            }
        }
    }
}
