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
    public class SubProcesoController : ControllerBase
    {
        private readonly ISubProcesoRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public SubProcesoController(ISubProcesoRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [Authorize]
        [HttpGet("registrodiario/subproceso/{procesoId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SubProcesoDTO>>> GetSubProcesosByProcesoId(int procesoId)
        {
            var subProcesos = await _usRepo.GetSubProcesosByProcesoIdAsync(procesoId);
            return Ok(subProcesos);
        }
    }
}
