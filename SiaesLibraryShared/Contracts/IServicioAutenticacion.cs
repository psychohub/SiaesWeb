using SiaesLibraryShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioAutenticacion
    {
        Task<RespuestaRegistro> RegistrarUsuario(UsuarioRegistro usuarioParaRegistro);

        Task<RespuestaAutenticacion> Acceder(UsuarioAutenticacion usuarioDesdeAutenticacion);

        Task Salir();
    }
}
