using Blazored.LocalStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace SiaesServer.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _bd;
        private string claveSecreta;
        private readonly ILocalStorageService _localStorage;
        public UsuarioRepositorio(AppDbContext bd, IConfiguration config, ILocalStorageService localStorage)
        {
            _bd = bd;
            _localStorage = localStorage;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
          
    }

        public Usuario GetUsuario(int usuarioId)
        {

            return _bd.Usuario.FirstOrDefault(c => c.Id == usuarioId);
            

        }

    
    

        public ICollection<Usuario> GetUsuarios()
        {
            return  _bd.Usuario.OrderBy(c => c.Id).ToList();
           
        }

        public bool IsUniqueUser(string usuario)
        {
            var usuariobd = _bd.Usuario.FirstOrDefault(u => u.NombreUsuario == usuario);
            if (usuariobd == null)
            {
                return true;
            }
            return false;
        }

        public async Task<UsuarioLoginRespuestaDTO> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            var passwordEncriptado = obtenermd5(usuarioLoginDTO.Clave);

            var usuario = _bd.Usuario.FirstOrDefault(
            u => u.NombreUsuario.ToLower() == usuarioLoginDTO.NombreUsuario.ToLower()
            && u.Clave == passwordEncriptado
            && u.CodEstablecimiento == usuarioLoginDTO.CodEstablecimiento
            && u.Perfil == usuarioLoginDTO.Perfil
            && u.Estado == 1);
            //Validamos si el usuario no existe con la combinación de usuario y contraseña correcta
            if (usuario == null)
            {
                return new UsuarioLoginRespuestaDTO()
                {
                    Token = "",
                    Usuario = null
                };
            }

            //sí existe el usuario
            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadorToken.CreateToken(tokenDescriptor);
            UsuarioLoginRespuestaDTO usuarioLoginRespuestaDTO = new UsuarioLoginRespuestaDTO()
            {
                Token = manejadorToken.WriteToken(token),
                Usuario = usuario

            };
            return usuarioLoginRespuestaDTO;
        }



        public async Task<Usuario> Registro(UsuarioRegistroDTO usuarioRegistroDTO)
        {
            var passwordEncriptado = obtenermd5(usuarioRegistroDTO.Clave);

            UsuarioRegistro usuarioRegistro = new UsuarioRegistro()
            {
                NombreUsuario = usuarioRegistroDTO.NombreUsuario,
                Nombre = usuarioRegistroDTO.Nombre,
                Apellidos = usuarioRegistroDTO.Apellidos,
                Correo = usuarioRegistroDTO.Correo,
                CodEstablecimiento = usuarioRegistroDTO.CodEstablecimiento,
                Clave = passwordEncriptado,
                Perfil = usuarioRegistroDTO.Perfil,
                Estado = usuarioRegistroDTO.Estado,
                FechaCaducidad = usuarioRegistroDTO.FechaCaducidad,
                UsuarioCreacion = usuarioRegistroDTO.UsuarioCreacion,
                FechaCreacion = usuarioRegistroDTO.FechaCreacion
            };

            // Mapear las propiedades de UsuarioRegistro a Usuario
            Usuario usuario = new Usuario()
            {
                NombreUsuario = usuarioRegistro.NombreUsuario,
                Nombre = usuarioRegistro.Nombre,
                Apellidos = usuarioRegistro.Apellidos,
                Correo = usuarioRegistro.Correo,
                CodEstablecimiento = usuarioRegistro.CodEstablecimiento,
                Clave = usuarioRegistro.Clave,
                Perfil = usuarioRegistro.Perfil,
                Estado = usuarioRegistro.Estado,
                FechaCaducidad = usuarioRegistro.FechaCaducidad,
                UsuarioCreacion = usuarioRegistro.UsuarioCreacion,
                FechaCreacion = usuarioRegistro.FechaCreacion,
                IdRol = 6,
                IdSubArea = 5
            };

            using (var transaction = await _bd.Database.BeginTransactionAsync())
            {
                try
                {
                    _bd.Usuario.Add(usuario);
                    await _bd.SaveChangesAsync();

                    Establecimiento establecimiento = new Establecimiento()
                    {
                        UsuarioId = usuario.Id,
                        CodEstablecimiento = usuarioRegistroDTO.CodEstablecimiento
                    };
                    _bd.Establecimientos.Add(establecimiento);

                    //UsuarioEstablecimiento usuarioEstablecimiento = new UsuarioEstablecimiento()
                    //{
                    //    UsuarioId = usuario.Id,
                    //    EstablecimientoId = establecimiento.Id
                    //};
                    //_bd.UsuarioEstablecimientos.Add(usuarioEstablecimiento);

                    UsuarioPerfil usuarioPerfil = new UsuarioPerfil()
                    {
                        UsuarioId = usuario.Id,
                        PerfilId = usuarioRegistroDTO.Perfil
                    };
                    _bd.UsuarioPerfiles.Add(usuarioPerfil);

                    await _bd.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            return usuario;
        }

        //Método para encriptar contraseña con MD5 se usa tanto en el Acceso como en el Registro
        public static string obtenermd5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }

        public async Task<bool> ExisteAsociacionUsuarioEstablecimientoPerfil(UsuarioAsociacionDTO usuarioAsociacionDTO)
        {
            return await _bd.UsuarioEstablecimientoPerfil.AnyAsync(uep => uep.NombreUsuario == usuarioAsociacionDTO.NombreUsuario
                     && uep.EstablecimientoId == usuarioAsociacionDTO.CodEstablecimiento
                     && uep.PerfilId == usuarioAsociacionDTO.Perfil);
        }

        public async Task<IEnumerable<Rol>> GetRoles()
        {
            try
            {
                return await _bd.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                // Registrar o manejar la excepción
                throw new Exception($"Error al obtener los roles: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<SubArea>> GetSubAreas()
        {
            try
            {
                return await _bd.SubAreas.ToListAsync();
            }
            catch (Exception ex)
            {
                // Registrar o manejar la excepción
                throw new Exception($"Error al obtener las subareas: {ex.Message}", ex);
            }
         
        }

        public async Task<Usuario?> GetUsuarioById(int id)
        {
            return await _bd.Usuario
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<IEnumerable<Usuario>> ActualizarUsuario(Usuario usuario)
        {
            var usuariosExistentes = await _bd.Usuario
                .Where(u => u.NombreUsuario == usuario.NombreUsuario)
                .ToListAsync();

            if (usuariosExistentes.Count == 0)
            {
                throw new Exception("No se encontraron usuarios con el nombre de usuario especificado");
            }

            foreach (var usuarioExistente in usuariosExistentes)
            {
                if (usuario.IdRol != 0)
                {
                    usuarioExistente.IdRol = usuario.IdRol;
                }

                if (usuario.IdSubArea != 0)
                {
                    usuarioExistente.IdSubArea = usuario.IdSubArea;
                }
            }

            await _bd.SaveChangesAsync();
            return usuariosExistentes;
        }

        public async Task<Usuario?> GetUsuarioByNombreUsuario(string nombreUsuario)
        {
            return await _bd.Usuario.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<Usuario> ObtenerUsuarioId(string nombreUsuario, int codEstablecimiento)
        {
            return _bd.Usuario.FirstOrDefault(c => c.NombreUsuario == nombreUsuario && c.CodEstablecimiento == codEstablecimiento);
        }

    }
}
