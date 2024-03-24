using AutoMapper;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class ProcesoServicio : IServicioProcesoRepositorio
    {
        private readonly IProcesoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ProcesoServicio(IProcesoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProcesoDTO>> GetProcesosAsync()
        {
            var procesos = await _repositorio.GetProcesosAsync();
            return _mapper.Map<IEnumerable<ProcesoDTO>>(procesos);
        }

    }
}
