using SiaesLibraryShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioIEMUsuarioInforme
    {
        Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme);
        Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme);
        Task<List<IEMInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento);
        Task<IEnumerable<IEMInforme>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento);
        Task<IEMInforme> ObtenerInformePorCodigo(string codigoInforme);
        Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes();
    }
}
