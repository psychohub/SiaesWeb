using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Repositories
{
    public class TUbicacionRepositorio : ITUbicacionRepositorio
    {
        private readonly AppDbContext _bd;


        public TUbicacionRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;

        }

        public async Task<IEnumerable<TUbicacion>> GetUbicacionAsync()
        {
            return await _bd.T_Ubicacion.ToListAsync();
        }
    }
}
