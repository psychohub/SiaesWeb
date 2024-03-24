using AutoMapper;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class TUbicacionServicio : IServicioTUbicacion
    {
        private readonly ITUbicacionRepositorio _repositorio;
        private readonly IMapper _mapper;

        public TUbicacionServicio(ITUbicacionRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TUbicacionDTO>> GetUbicacionAsync()
        {
            var procesos = await _repositorio.GetUbicacionAsync();
            return _mapper.Map<IEnumerable<TUbicacionDTO>>(procesos);
        }
    }
}
