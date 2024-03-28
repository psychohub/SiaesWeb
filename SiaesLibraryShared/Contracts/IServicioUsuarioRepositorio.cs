using SiaesLibraryShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioUsuarioRepositorio
    {
        Task<IEnumerable<Rol>> GetRoles();
        Task<IEnumerable<SubArea>> GetSubAreas();
        Task<Usuario?> GetUsuarioByNombreUsuario(string nombreUsuario);

        Task<Usuario?> ObtenerUsuarioId(string nombreUsuario, int codEstablecimiento);
        Task<AsociarUsuarioResponse> ActualizarUsuario(Usuario usuario);

    }
}
