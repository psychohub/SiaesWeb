using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiaesLibraryShared.Models;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class DetalleProcesoController : ControllerBase
    {
        private readonly IDetalleProcesoRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

      
        public DetalleProcesoController(IDetalleProcesoRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }


        [Authorize]
        [HttpGet("detalleProceso/{idProceso}/{idSubProceso}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerIdDetalleProceso(int idProceso, int idSubProceso)
        {
            var idDetalleProceso = await _usRepo.ObtenerIdDetalleProceso(idProceso, idSubProceso);
            return Ok(idDetalleProceso);
        }

    }
}
