using AutoMapper;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class ServicioTRegistroDiario : IServicioTRegistroDiario
    {
        private readonly ITRegistroDiario _repositorio;
        private readonly IMapper _mapper;

        public ServicioTRegistroDiario(ITRegistroDiario repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<TRegistroDiarioDTO>> ObtenerRegistrosDiarios()
        {
            var registrosDiarios = await _repositorio.ObtenerRegistrosDiarios();
            return _mapper.Map<List<TRegistroDiarioDTO>>(registrosDiarios);
        }

        public async Task<TRegistroDiarioDTO> ObtenerRegistroDiarioPorId(int id)
        {
            var registroDiario = await _repositorio.ObtenerRegistroDiarioPorId(id);
            return _mapper.Map<TRegistroDiarioDTO>(registroDiario);
        }

        public async Task<bool> CrearRegistroDiario(TRegistroDiarioDTO registroDiarioDTO)
        {
            var registroDiario = _mapper.Map<TRegistroDiario>(registroDiarioDTO);
            return await _repositorio.CrearRegistroDiario(registroDiario);
        }

        public async Task<bool> ActualizarRegistroDiario(TRegistroDiarioDTO registroDiarioDTO)
        {
            var registroDiario = _mapper.Map<TRegistroDiario>(registroDiarioDTO);
            return await _repositorio.ActualizarRegistroDiario(registroDiario);
        }

        public async Task<bool> EliminarRegistroDiario(int id)
        {
            return await _repositorio.EliminarRegistroDiario(id);
        }

        public async Task<bool> CrearRegistroDiario(RegistroDiarioCreacionDTO registroDiarioCreacionDTO)
        {
            var registroDiario = _mapper.Map<TRegistroDiario>(registroDiarioCreacionDTO);
            return await _repositorio.CrearRegistroDiario(registroDiario);
        }
    }

}
