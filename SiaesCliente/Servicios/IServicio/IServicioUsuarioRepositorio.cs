using SiaesLibraryShared.Models;

namespace SiaesCliente.Servicios.IServicio
{
    public interface IServicioUsuarioRepositorio
    {
        Task<IEnumerable<Rol>> GetRoles();
        Task<IEnumerable<SubArea>> GetSubAreas();
        Task<Usuario?> GetUsuarioByNombreUsuario(string nombreUsuario);
        Task<AsociarUsuarioResponse?> ActualizarUsuario(Usuario usuario);
        Task<Usuario?> ObtenerUsuarioId(string nombreUsuario, int codEstablecimiento);
    }
}
