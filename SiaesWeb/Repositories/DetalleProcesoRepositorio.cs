using Microsoft.EntityFrameworkCore;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Repositories
{
    public class DetalleProcesoRepositorio : IDetalleProcesoRepositorio
    {
        private readonly AppDbContext _bd;


        public DetalleProcesoRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;

        }

        public async Task<int> ObtenerIdDetalleProceso(int idProceso, int idSubProceso)
        {
            var idDetalleProceso = await _bd.T_DetalleProceso
         .Where(dp => dp.IdProceso == idProceso && dp.IdSubProceso == idSubProceso)
         .Select(dp => dp.IdDetalleProceso)
         .FirstOrDefaultAsync();

            return idDetalleProceso;
        }
    }
}
