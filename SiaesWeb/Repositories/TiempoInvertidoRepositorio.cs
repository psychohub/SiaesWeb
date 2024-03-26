using Microsoft.EntityFrameworkCore;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Repositories
{
    public class TiempoInvertidoRepositorio : ITiempoInvertidoRepositorio
    {
        private readonly AppDbContext _bd;


        public TiempoInvertidoRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;

        }
        public async Task<decimal> GetTotalTiempoInvertidoAsync(int idFuncionario, DateTime fechaActividad)
        {
            return await _bd.T_RegistroDiario
      .Where(r => r.IdFuncionario == idFuncionario && r.FechaActividad == fechaActividad)
      .SumAsync(r => r.TiempoInvertido);
        }
    }
}
