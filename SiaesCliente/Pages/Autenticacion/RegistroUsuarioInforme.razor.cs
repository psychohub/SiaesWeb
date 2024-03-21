using Microsoft.AspNetCore.Components;
using SiaesCliente.Servicios;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using System.Reflection;

namespace SiaesCliente.Pages.Autenticacion
{
    public partial class RegistroUsuarioInforme : ComponentBase
    {
        private string nombreUsuario = string.Empty;
        private int? codEstablecimiento;
        private bool EstaProcesando = false;
        private bool MostrarErroresRegistro = false;
        private List<string> Errores = new List<string>();
        private List<IEMInforme> informesDisponibles = new List<IEMInforme>();
        private List<IEMInforme> informesAsociados = new List<IEMInforme>();
        private IEMUsuarioInforme usuarioInforme = new IEMUsuarioInforme();

        [Inject] private IServicioIEMUsuarioInforme servicioIEMUsuarioInforme { get; set; }



        protected override async Task OnInitializedAsync()
        {
           
        }

        private async Task CargarInformesAsociados()
        {
            if (!string.IsNullOrEmpty(model.NombreUsuario) && model.CodEstablecimiento > 0)
            {
                var informesAsociadosUsuario = await servicioIEMUsuarioInforme.ObtenerInformesAsociados(model.NombreUsuario, model.CodEstablecimiento);
                model.InformesAsociados = informesAsociadosUsuario.Select(x => x.Informe).ToList();
            }
        }

        private async Task AsociarInforme(IEMInforme informe)
        {
            if (informe != null)
            {
                var resultado = await servicioIEMUsuarioInforme.AsociarInformes(model.NombreUsuario, model.CodEstablecimiento, new List<string> { informe.COD_INFORME });
                if (resultado)
                {
                    await CargarInformesAsociados();
                    model.InformesDisponibles = (await servicioIEMUsuarioInforme.ObtenerInformesDisponibles(model.NombreUsuario, model.CodEstablecimiento)).ToList();
                }
            }
        }

        private async Task DesasociarInforme(IEMInforme informe)
        {
            if (informe != null)
            {
                var resultado = await servicioIEMUsuarioInforme.DesasociarInformes(model.NombreUsuario, model.CodEstablecimiento, new List<string> { informe.COD_INFORME });
                if (resultado)
                {
                    await CargarInformesAsociados();
                    model.InformesDisponibles = (await servicioIEMUsuarioInforme.ObtenerInformesDisponibles(model.NombreUsuario, model.CodEstablecimiento)).ToList();
                }
            }
        }

        private async Task RegistrarUsuarioInforme()
        {
            EstaProcesando = true;
            MostrarErroresRegistro = false;
            Errores.Clear();

            if (!string.IsNullOrEmpty(model.NombreUsuario) && model.CodEstablecimiento > 0)
            {
                await CargarInformesAsociados();
                model.InformesDisponibles = (await servicioIEMUsuarioInforme.ObtenerInformesDisponibles(model.NombreUsuario, model.CodEstablecimiento)).ToList();
                EstaProcesando = false;
            }
            else
            {
                Errores.Add("Debe ingresar un usuario y un establecimiento válidos.");
                MostrarErroresRegistro = true;
                EstaProcesando = false;
            }
        }

        private RegistroUsuarioInformeModel model = new RegistroUsuarioInformeModel();
        private class RegistroUsuarioInformeModel
        {
            public string NombreUsuario { get; set; }
            public int CodEstablecimiento { get; set; }
            public List<IEMInforme> InformesAsociados { get; set; } = new List<IEMInforme>();
            public List<IEMInforme> InformesDisponibles { get; set; } = new List<IEMInforme>();
        }
    }
}
