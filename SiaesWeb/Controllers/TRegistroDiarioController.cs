using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Radzen.Blazor.Rendering;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories;
using SiaesServer.Repositories.IRepositories;
using System.Net;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class TRegistroDiarioController : ControllerBase
    {
        private readonly ITRegistroDiario _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public TRegistroDiarioController(ITRegistroDiario usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }



        [HttpGet("registrodiario/obtenerPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TRegistroDiarioDTO>> ObtenerRegistroDiarioPorId(int id)
        {
            var registroDiario = await _usRepo.ObtenerRegistroDiarioPorId(id);
            if (registroDiario == null)
            {
                _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add("Error al asociar informes");
                return BadRequest(_respuestasAPI);
            }
            return Ok(registroDiario);
        }

        [Authorize]
        [HttpPost("registrodiario/crear")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
          public async Task<ActionResult<TRegistroDiarioDTO>> CrearRegistroDiario(RegistroDiarioCreacionDTO registroDiarioCreacionDTO)
        {
            try
            {
                var resultado = await _usRepo.CrearRegistroDiario(registroDiarioCreacionDTO);
                if (!resultado)
                {
                    _respuestasAPI.StatusCode = HttpStatusCode.BadRequest;
                    _respuestasAPI.IsSuccess = false;
                    _respuestasAPI.ErrorsMessages.Add("Error al crear el registro");
                    return BadRequest(_respuestasAPI);
                }

                var registroDiarioDTO = _mapper.Map<TRegistroDiarioDTO>(registroDiarioCreacionDTO);
                return CreatedAtAction(nameof(ObtenerRegistroDiarioPorId), new { id = registroDiarioDTO.IdRegistro }, registroDiarioDTO);
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver una respuesta de error adecuada
                _respuestasAPI.StatusCode = HttpStatusCode.InternalServerError;
                _respuestasAPI.IsSuccess = false;
                _respuestasAPI.ErrorsMessages.Add($"Error interno del servidor: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, _respuestasAPI);
            }
        }

 


    }
}
