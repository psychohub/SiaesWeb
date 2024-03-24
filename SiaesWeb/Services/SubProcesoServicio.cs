using AutoMapper;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class SubProcesoServicio : IServicioSubProcesoRepositorio
    {
        private readonly ISubProcesoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public SubProcesoServicio(ISubProcesoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubProcesoDTO>> GetSubProcesosByProcesoIdAsync(int procesoId)
        {
            var subProcesos = await _repositorio.GetSubProcesosByProcesoIdAsync(procesoId);
            return _mapper.Map<IEnumerable<SubProcesoDTO>>(subProcesos);
        }
    }
}
