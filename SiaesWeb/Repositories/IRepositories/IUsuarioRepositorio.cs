using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using static SiaesCliente.Pages.Autenticacion.OlvidoContrasena;

namespace SiaesServer.Repositories.IRepositories
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int usuarioId);
        Task<Usuario?> ObtenerUsuarioId(string nombreUsuario, int codEstablecimiento);
        bool IsUniqueUser(string usuario);

        Task<IEnumerable<Rol>> GetRoles();
        Task<IEnumerable<SubArea>> GetSubAreas();
        Task<Usuario> GetUsuarioById(int usuarioId);
        Task<IEnumerable<Usuario>> ActualizarUsuario(Usuario usuario);
        Task<Usuario?> GetUsuarioByNombreUsuario(string nombreUsuario);

        Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLoginDTO);
        Task<Usuario> Registro(UsuarioRegistroDTO usuarioRegistroDTO);

        Task<bool> ExisteAsociacionUsuarioEstablecimientoPerfil(UsuarioAsociacionDTO usuarioAsociacionDTO);
        Task<bool> CambiarClave(UsuarioCambiarClaveDTO usuarioCambiarClaveDTO);

        Task<bool> EnviarNuevaContrasena(OlvidoContrasenaDTO model);
    }
}
