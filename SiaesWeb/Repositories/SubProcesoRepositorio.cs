using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Repositories 
{
    public class SubProcesoRepositorio : ISubProcesoRepositorio
    {
        private readonly AppDbContext _bd;


        public SubProcesoRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;

        }

        public async Task<IEnumerable<TSubProceso>> GetSubProcesosByProcesoIdAsync(int procesoId)
        {
            return await _bd.T_SubProceso
         .Join(_bd.T_DetalleProceso,
             sp => sp.IdSubProceso,
             dp => dp.IdSubProceso,
             (sp, dp) => new { SubProceso = sp, DetalleProceso = dp })
         .Where(x => x.DetalleProceso.IdProceso == procesoId)
         .Select(x => x.SubProceso)
         .ToListAsync();
        }
    }
}
