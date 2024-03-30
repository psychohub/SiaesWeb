using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;
using System.Globalization;
using System.Net;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class RegistroDiarioController : ControllerBase
    {
        private readonly IRegistroDiarioRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public RegistroDiarioController(IRegistroDiarioRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [Authorize]
        [HttpGet("registrodiario/obtener/{idFuncionario}/{idSubArea}/{fechaActividad}/{idRol}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<RegistroDiarioDTO>>> ObtenerRegistros(int? idFuncionario, int? idSubArea, string fechaActividad, int idRol)
        {
            var fechaActividadDateTime = DateTime.ParseExact(fechaActividad, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            try
            {
                var registros = await _usRepo.ObtenerRegistros(idFuncionario, idSubArea, fechaActividadDateTime, idRol);

                if (registros == null || !registros.Any())
                {
                    _respuestasAPI.StatusCode = HttpStatusCode.NotFound;
                    _respuestasAPI.IsSuccess = false;
                    _respuestasAPI.ErrorsMessages.Add("No se encontraron registros diarios");
                    return NotFound(_respuestasAPI);
                }

                return Ok(registros);
            }
            catch (Exception ex)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.InternalServerError;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add($"Error al obtener los registros diarios: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, _respuestasAPI);
            }
        }

        [Authorize]
        [HttpDelete("registrodiario/eliminar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarRegistroDiario(RegistroDiarioEliminarDTO dto)
        {
            try
            {
                var resultado = await _usRepo.EliminarRegistroDiario(dto);
                if (resultado)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.InternalServerError;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add($"Error al eliminar el registro diario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, _respuestasAPI);
            }
        }
    }
}
