using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class ServicioUsuarioRepositorio : IServicioUsuarioRepositorio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ServicioUsuarioRepositorio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<IEnumerable<Rol>> GetRoles()
        {
            return await _usuarioRepositorio.GetRoles();
        }

        public async Task<IEnumerable<SubArea>> GetSubAreas()
        {
            return await _usuarioRepositorio.GetSubAreas();
        }

        public async Task<Usuario> GetUsuarioById(int usuarioId)
        {
            return await _usuarioRepositorio.GetUsuarioById(usuarioId);
        }

        public async Task<IEnumerable<Usuario>> ActualizarUsuario(Usuario usuario)
        {
            return await _usuarioRepositorio.ActualizarUsuario(usuario);
        }

        public async Task<Usuario?> GetUsuarioByNombreUsuario(string nombreUsuario)
        {
            return await _usuarioRepositorio.GetUsuarioByNombreUsuario(nombreUsuario);
        }

        Task<AsociarUsuarioResponse?> IServicioUsuarioRepositorio.ActualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
