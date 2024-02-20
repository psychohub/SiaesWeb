using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;
using System.Net;

namespace SiaesServer.Controllers
{
    [Route("api/registrar_usuario")]
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
            int establecimiento = usuarioLoginDTO.Establecimiento; // Aquí se obtiene el valor como entero
            int selectedPerfil = usuarioLoginDTO.SelectedPerfil;



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
            _respuestasAPI.Result = respuestaLogin;
            return Ok(_respuestasAPI);
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

    }
}
