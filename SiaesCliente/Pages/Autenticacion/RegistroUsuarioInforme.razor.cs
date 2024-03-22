using Microsoft.AspNetCore.Components;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;

namespace SiaesCliente.Pages.Autenticacion
{
    public partial class RegistroUsuarioInforme : ComponentBase
    {
      
        private bool EstaProcesando { get; set; }
        private bool MostrarErroresRegistro { get; set; }
        private List<string> Errores { get; set; } = new List<string>();


        [Inject] private IServicioIEMUsuarioInforme servicioIEMUsuarioInforme { get; set; }



        protected override async Task OnInitializedAsync()
        {
           
        }

        private async Task CargarInformesAsociados()
        {
            if (!string.IsNullOrEmpty(model.NombreUsuario) && model.CodEstablecimiento > 0)
            {
                model.InformesAsociados = await servicioIEMUsuarioInforme.ObtenerInformesAsociados(model.NombreUsuario, model.CodEstablecimiento);
                model.InformesDisponibles = (List<IEMInforme>)await servicioIEMUsuarioInforme.ObtenerInformesDisponibles(model.NombreUsuario, model.CodEstablecimiento);

                var todosLosInformes = await servicioIEMUsuarioInforme.ObtenerTodosLosInformes();
                model.TodosLosInformes = todosLosInformes.ToDictionary(i => i.COD_INFORME, i => i.DSC_INFORME);
            }
        }

        private async Task AsociarInforme()
        {
            var codigosInforme = new List<string> { model.InformesDisponiblesSeleccionados };
            var resultado = await servicioIEMUsuarioInforme.AsociarInformes(model.NombreUsuario, model.CodEstablecimiento, codigosInforme);
            if (resultado)
            {
                await CargarInformesAsociados();
                model.InformesDisponiblesSeleccionados = string.Empty;
            }
        }

        private async Task DesasociarInforme()
        {
            var codigosInforme = new List<string> { model.InformesAsociadosSeleccionados };
            var resultado = await servicioIEMUsuarioInforme.DesasociarInformes(model.NombreUsuario, model.CodEstablecimiento, codigosInforme);
            if (resultado)
            {
                await CargarInformesAsociados();
                model.InformesAsociadosSeleccionados = string.Empty;
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
            public string InformesDisponiblesSeleccionados { get; set; }
            public string InformesAsociadosSeleccionados { get; set; }
            public Dictionary<string, string> TodosLosInformes { get; set; } = new Dictionary<string, string>();
        }
    }
}
