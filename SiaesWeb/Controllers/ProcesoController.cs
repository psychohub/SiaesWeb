using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class ProcesoController : ControllerBase
    {
        private readonly IProcesoRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public ProcesoController(IProcesoRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [Authorize]
        [HttpGet("registrodiario/procesos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProcesoDTO>>> GetProcesos()
        {
            var procesos = await _usRepo.GetProcesosAsync();
            return Ok(procesos);
        }

    }
}
