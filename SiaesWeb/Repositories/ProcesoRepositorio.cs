
using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Repositories
{
    public class ProcesoRepositorio : IProcesoRepositorio
    {
        private readonly AppDbContext _bd;


        public ProcesoRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;

        }


        public async Task<IEnumerable<TProceso>> GetProcesosAsync()
        {
            return await _bd.T_Proceso.ToListAsync();
        }

    
    }
}
