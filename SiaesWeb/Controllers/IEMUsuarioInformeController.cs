using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Radzen.Blazor.Rendering;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;
using System.Net;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class IEMUsuarioInformeController : ControllerBase
    {
        private readonly IIEMUsuarioInforme _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public IEMUsuarioInformeController(IIEMUsuarioInforme usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [Authorize]
        [HttpGet("informes")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<IEMInforme>>> ObtenerTodosLosInformes()
        {
            var informesTotales = await _usRepo.ObtenerTodosLosInformes();
            return Ok(informesTotales);
        }

        [Authorize]
        [HttpGet("informes/codigo/{codigoInforme}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEMInforme>> ObtenerInformePorCodigo(string codigoInforme)
        {
            var informe = await _usRepo.ObtenerInformePorCodigo(codigoInforme);
            return Ok(informe);
        }

        [Authorize]
        [HttpPost("asociar/{nombreUsuario}/{codEstablecimiento}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AsociarInformes(string nombreUsuario, int codEstablecimiento, [FromBody] List<string> codigosInforme)
        {
            var resultado = await _usRepo.AsociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Error al asociar informes");
                return BadRequest(_respuestasAPI);
            }
        }

        [Authorize]
        [HttpDelete("desasociar/{nombreUsuario}/{codEstablecimiento}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DesasociarInformes(string nombreUsuario, int codEstablecimiento, [FromBody] List<string> codigosInforme)
        {
            var resultado = await _usRepo.DesasociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Error al desasociar informes");
                return BadRequest(_respuestasAPI);
            }
        }

        [Authorize]
        [HttpGet("informes/disponibles/{nombreUsuario}/{codEstablecimiento}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<IEMInforme>>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento)
        {
            var informesDisponibles = await _usRepo.ObtenerInformesDisponibles(nombreUsuario, codEstablecimiento);
            return Ok(informesDisponibles);
        }

        [Authorize]
        [HttpGet("informes/asociados/{nombreUsuario}/{codEstablecimiento}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<IEMInforme>>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            var informesDisponibles = await _usRepo.ObtenerInformesAsociados(nombreUsuario, codEstablecimiento);
            return Ok(informesDisponibles);
        }
    }
}
