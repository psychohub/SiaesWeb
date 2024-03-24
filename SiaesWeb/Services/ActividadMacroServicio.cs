using AutoMapper;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class ActividadMacroServicio : IServicioActividadMacroRepositorio
    {
        private readonly IActividadMacroRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ActividadMacroServicio(IActividadMacroRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TActividadMacroDTO>> GetActividadesMacroAsync()
        {
            var actividadesMacro = await _repositorio.GetActividadesMacroAsync();
            return _mapper.Map<IEnumerable<TActividadMacroDTO>>(actividadesMacro);
        }
    }
}
