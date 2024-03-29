using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiaesLibraryShared.Models;
using SiaesServer.Repositories.IRepositories;
using System.Globalization;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class TiempoInvertidoController : ControllerBase
    {
        private readonly ITiempoInvertidoRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public TiempoInvertidoController(ITiempoInvertidoRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [Authorize]
        [HttpGet("registrodiario/tiempoinvertido/{idFuncionario}/{fechaActividad}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<decimal> GetTotalTiempoInvertidoAsync(int idFuncionario, string fechaActividad)
        {
            var fechaActividadDateTime = DateTime.ParseExact(fechaActividad, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var totalTiempoInvertido = await _usRepo.GetTotalTiempoInvertidoAsync(idFuncionario, fechaActividadDateTime);
            return totalTiempoInvertido;
        }
    }
}
