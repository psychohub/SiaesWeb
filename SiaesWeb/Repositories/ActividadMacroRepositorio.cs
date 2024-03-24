using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Repositories
{
    public class ActividadMacroRepositorio : IActividadMacroRepositorio
    {
        private readonly AppDbContext _bd;


        public ActividadMacroRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;

        }

        public async Task<IEnumerable<TActividadMacro>> GetActividadesMacroAsync()
        {
            return await _bd.T_ActividadMacro.ToListAsync();
        }
    }
}
