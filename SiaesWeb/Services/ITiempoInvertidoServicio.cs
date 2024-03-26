using AutoMapper;
using SiaesLibraryShared.Contracts;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class ITiempoInvertidoServicio : IServicioTiempoInvertidoServicio
    {
        private readonly ITiempoInvertidoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ITiempoInvertidoServicio(ITiempoInvertidoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<decimal> GetTotalTiempoInvertidoAsync(int idFuncionario, DateTime fechaActividad)
        {
            var totalTiempoInvertido = await _repositorio.GetTotalTiempoInvertidoAsync(idFuncionario, fechaActividad);
            return totalTiempoInvertido;
        }
    }
}
