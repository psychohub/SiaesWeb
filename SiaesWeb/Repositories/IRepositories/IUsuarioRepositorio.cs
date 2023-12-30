using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;

namespace SiaesServer.Repositories.IRepositories
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int usuarioId);
        bool IsUniqueUser(string usuario);

        Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLoginDTO);
        Task<Usuario> Registro(UsuarioRegistroDTO usuarioRegistroDTO);
    }
}
