
using Microsoft.AspNetCore.Mvc;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Responses;

namespace SiaesServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanuController : ControllerBase
    {
        private readonly ITanu tanuService;

        public TanuController(ITanu tanuService)
        {
            this.tanuService = tanuService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Model_Tanu>>> GetAllTanus(string NumeroIdentificacionRecienNacido)
        {
            var tanus = await tanuService.GetAllTanus(NumeroIdentificacionRecienNacido); return Ok(tanus);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddTanu(Model_Tanu model)
        {
            if (model is null) return BadRequest("Model is null");
            var response = await tanuService.AddTanu(model);
            return Ok(response);
        }

    }
}
