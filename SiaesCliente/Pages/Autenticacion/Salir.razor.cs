using Microsoft.AspNetCore.Components;
using SiaesLibraryShared.Contracts;

namespace SiaesCliente.Pages.Autenticacion
{
    public partial class Salir
    {

        [Inject]
        public IServicioAutenticacion servicioAutenticacion { get; set; }

    }
}
