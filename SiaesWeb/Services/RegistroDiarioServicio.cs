using AutoMapper;
using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Services
{
    public class RegistroDiarioServicio : IRegistroDiarioServicio
    {
        private readonly IRegistroDiarioRepositorio _repositorio;
        private readonly IMapper _mapper;

        public RegistroDiarioServicio(IRegistroDiarioRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<bool> EliminarRegistroDiario(RegistroDiarioEliminarDTO dto)
        {
            try
            {
                var resultado = await _repositorio.EliminarRegistroDiario(dto);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el registro diario: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<RegistroDiarioDTO>> ObtenerRegistros(int? IdFuncionario, int? IdSubArea, DateTime FechaActividad, int IdRol)
        {
            try
            {
                var registros = await _repositorio.ObtenerRegistros(IdFuncionario, IdSubArea, FechaActividad, IdRol);
                return registros;
            }
            catch (Exception ex)
            {
               
                throw new Exception($"Error al obtener los registros diarios: {ex.Message}", ex);
            }
        }
    }
}
