using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories;
using SiaesServer.Repositories.IRepositories;
using System.Net;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [Authorize]
        [HttpPost("registro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registro([FromBody] UsuarioRegistroDTO usuarioRegistroDTO)
        {
            if (usuarioRegistroDTO == null)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Datos de usuario inválidos");
                return BadRequest(_respuestasAPI);
            }

            // Crear el objeto UsuarioAsociacionDTO con los datos necesarios
            var usuarioAsociacion = new UsuarioAsociacionDTO
            {
                NombreUsuario = usuarioRegistroDTO.NombreUsuario, 
                CodEstablecimiento = usuarioRegistroDTO.CodEstablecimiento,
                Perfil = usuarioRegistroDTO.Perfil
            };

            // Verificar si ya existe una asociación de Usuario, Establecimiento y Perfil en la base de datos
            var existeAsociacion = await _usRepo.ExisteAsociacionUsuarioEstablecimientoPerfil(usuarioAsociacion);
            if (existeAsociacion)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Ya existe una asociación de Usuario, Establecimiento y Perfil");
                return BadRequest(_respuestasAPI);
            }

            var usuario = await _usRepo.Registro(usuarioRegistroDTO);
            if (usuario == null)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Error al registrar usuario");
                return BadRequest(_respuestasAPI);
            }
            if (_respuestasAPI == null)
            {
                _respuestasAPI = new RespuestasAPI();
            }

            _respuestasAPI.StatusCode = HttpStatusCode.OK;
            _respuestasAPI.IsSuccess = true;
            return Ok(_respuestasAPI);
        }

   
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO usuarioLoginDTO)
        {
            int establecimiento = usuarioLoginDTO.CodEstablecimiento; // Aquí se obtiene el valor como entero
            int selectedPerfil = usuarioLoginDTO.Perfil;



            var respuestaLogin = await _usRepo.Login(usuarioLoginDTO);
            if (respuestaLogin.Usuario == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("El nombre de usuario o password son incorrectos");
                return BadRequest(_respuestasAPI);
            }

 
            _respuestasAPI.StatusCode = HttpStatusCode.OK;
            _respuestasAPI.IsSuccess = true;
            _respuestasAPI.StatusCode = HttpStatusCode.OK;
            _respuestasAPI.IsSuccess = true;
            _respuestasAPI.NombreUsuario = respuestaLogin.Usuario.NombreUsuario;
            _respuestasAPI.Perfil = respuestaLogin.Usuario.Perfil;
            _respuestasAPI.CodEstablecimiento = respuestaLogin.Usuario.CodEstablecimiento;
            _respuestasAPI.Result = new
            {
                Usuario = respuestaLogin.Usuario,
                Token = respuestaLogin.Token,
                Perfil = respuestaLogin.Usuario.Perfil,
                NombreUsuario = respuestaLogin.Usuario.NombreUsuario,
                Unidad = respuestaLogin.Usuario.CodEstablecimiento
            };

            return Ok(_respuestasAPI);
        }


        // Métodos para obtener roles y subáreas
        [HttpGet("roles")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            var roles = await _usRepo.GetRoles();
            return Ok(roles);
        }

        [HttpGet("subareas")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SubArea>>> GetSubAreas()
        {

            var subAreas = await _usRepo.GetSubAreas();
            return Ok(subAreas);
        }


        // Método para asociar un usuario con un rol y una subárea
        [Authorize]
        [HttpPut("asociar")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RespuestasAPI>> AsociarUsuario(Usuario usuario)
        {
            var usuarioExistente = await _usRepo.GetUsuarioByNombreUsuario(usuario.NombreUsuario);
            if (usuarioExistente == null)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.NotFound;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("El usuario no existe");
                return NotFound(_respuestasAPI);
            }

            usuarioExistente.IdRol = usuario.IdRol;
            usuarioExistente.IdSubArea = usuario.IdSubArea;

            var usuarioActualizado = await _usRepo.ActualizarUsuario(usuarioExistente);
            if (usuarioActualizado == null)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Error al asociar usuario");
                return BadRequest(_respuestasAPI);
            }

            _respuestasAPI.StatusCode = HttpStatusCode.OK;
            _respuestasAPI.IsSuccess = true;
            _respuestasAPI.Result = usuarioActualizado;
            return Ok(_respuestasAPI);
        }

        [Authorize]
        [HttpGet("nombreUsuario/{nombreUsuario}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Usuario>> GetUsuarioByNombreUsuario(string nombreUsuario)
        {
            var usuario = await _usRepo.GetUsuarioByNombreUsuario(nombreUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        //Métodos o endpoints de la API 
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _usRepo.GetUsuarios();

            var listaUsuariosDTO = new List<UsuarioDTO>();

            foreach (var lista in listaUsuarios)
            {
                listaUsuariosDTO.Add(_mapper.Map<UsuarioDTO>(lista));
            }
            return Ok(listaUsuariosDTO);
        }

        [Authorize]
        [HttpGet("{usuarioId:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsuario(int usuarioId)
        {
            var itemUsuario = _usRepo.GetUsuario(usuarioId);

            if (itemUsuario == null)
            {
                return NotFound();
            }

            var itemUsuarioDTO = _mapper.Map<UsuarioDTO>(itemUsuario);
            return Ok(itemUsuarioDTO);
        }

        [Authorize]
        [HttpGet("obtenerusuarioId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>> ObtenerUsuarioId(string nombreUsuario, int codEstablecimiento)
        {
            var usuario = await _usRepo.ObtenerUsuarioId(nombreUsuario, codEstablecimiento);

            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                _respuestasAPI.StatusCode = HttpStatusCode.NotFound;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Usuario no encontrado");
                return NotFound(_respuestasAPI);
            }
        }

        [Authorize]
        [HttpPut("cambiarclave")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CambiarClave(UsuarioCambiarClaveDTO usuarioCambiarClaveDTO)
        {
            var resultado = await _usRepo.CambiarClave(usuarioCambiarClaveDTO);

            if (resultado)
            {

                _respuestasAPI.StatusCode = HttpStatusCode.OK;
                _respuestasAPI.IsSuccess = true;
                _respuestasAPI.Result = "clave actualizada con éxito";
                return Ok(_respuestasAPI);
            }
            else
            {
                _respuestasAPI.StatusCode = HttpStatusCode.NotFound;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("No se pudo cambiar la clave.");
                return NotFound(_respuestasAPI);
        
            }
        }

        [HttpPost("olvidocontrasena")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> OlvidoContrasena(OlvidoContrasenaDTO model)
        {
            var resultado = await _usRepo.EnviarNuevaContrasena(model);

            if (resultado)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.OK;
                _respuestasAPI.IsSuccess = true;
                _respuestasAPI.Result = "contraseña enviada al correo";
                return Ok(_respuestasAPI);
            }
            else
            {
                _respuestasAPI.StatusCode = HttpStatusCode.NotFound;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Su usuario no es válido o su correo electrónico no está registrado");
                return NotFound(_respuestasAPI);

            }
        }


    }
}
