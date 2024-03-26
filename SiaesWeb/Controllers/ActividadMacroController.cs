
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Controllers
{
    [Route("api/siaes")]
    [ApiController]
    public class ActividadMacroController : ControllerBase
    {
        private readonly IActividadMacroRepositorio _usRepo;
        protected RespuestasAPI _respuestasAPI;
        private readonly IMapper _mapper;

        public ActividadMacroController(IActividadMacroRepositorio usRepo, IMapper mapper)
        {
            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestasAPI = new();
        }

        [HttpGet("registrodiario/actividadesmacros")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TActividadMacroDTO>>> GetActividadesMacro()
        {
            var actividadesMacro = await _usRepo.GetActividadesMacroAsync();
            return Ok(actividadesMacro);
        }
    }
}
