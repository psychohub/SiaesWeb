using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;

namespace SiaesServer.Controllers
{
    [Authorize]
    [Route("api/siaes/bitacora")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private readonly IServicioBitacora _servicioBitacora;

        public BitacoraController(IServicioBitacora servicioBitacora)
        {
            _servicioBitacora = servicioBitacora;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarAccion(BitacoraDTO bitacoraDTO)
        {
            var resultado = await _servicioBitacora.RegistrarAccion(bitacoraDTO);
            return Ok(resultado);
        }
    }
}
