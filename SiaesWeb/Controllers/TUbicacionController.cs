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
    public class TUbicacionController : ControllerBase
    {
        private readonly ITUbicacionRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public TUbicacionController(ITUbicacionRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [Authorize]
        [HttpGet("registrodiario/modalidad")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TUbicacionDTO>>> GetProcesos()
        {
            var ubicacion = await _usRepo.GetUbicacionAsync();
            return Ok(ubicacion);
        }
    }
}
