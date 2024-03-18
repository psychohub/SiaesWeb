using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Radzen.Blazor.Rendering;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using System.Net;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class IEMUsuarioInformeController : ControllerBase
    {
        private readonly IServicioIEMUsuarioInforme _servicioIEMUsuarioInforme;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public IEMUsuarioInformeController(IServicioIEMUsuarioInforme servicioIEMUsuarioInforme, IMapper mapper)
        {
            _servicioIEMUsuarioInforme = servicioIEMUsuarioInforme;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [HttpGet("informes/{nombreUsuario}/{codEstablecimiento}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<IEMUsuarioInforme>>> GetInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            var informesAsociados = await _servicioIEMUsuarioInforme.ObtenerInformesAsociados(nombreUsuario, codEstablecimiento);
            return Ok(informesAsociados);
        }

        [HttpPost("asociar/{nombreUsuario}/{codEstablecimiento}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AsociarInformes(string nombreUsuario, int codEstablecimiento, [FromBody] List<string> codigosInforme)
        {
            var resultado = await _servicioIEMUsuarioInforme.AsociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
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

        [HttpDelete("desasociar/{nombreUsuario}/{codEstablecimiento}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DesasociarInformes(string nombreUsuario, int codEstablecimiento, [FromBody] List<string> codigosInforme)
        {
            var resultado = await _servicioIEMUsuarioInforme.DesasociarInformes(nombreUsuario, codEstablecimiento, codigosInforme);
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
    }
}
