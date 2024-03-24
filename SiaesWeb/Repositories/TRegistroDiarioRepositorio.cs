using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace SiaesServer.Repositories
{
    public class TRegistroDiarioRepositorio : ITRegistroDiario
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TRegistroDiarioRepositorio(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TRegistroDiarioDTO>> ObtenerRegistrosDiarios()
        {
            var registrosDiarios = await _context.T_RegistroDiario.ToListAsync();
            return _mapper.Map<List<TRegistroDiarioDTO>>(registrosDiarios);
        }

        public async Task<TRegistroDiarioDTO> ObtenerRegistroDiarioPorId(int id)
        {
            var registroDiario = await _context.T_RegistroDiario.FindAsync(id);
            return _mapper.Map<TRegistroDiarioDTO>(registroDiario);
        }

        public async Task<bool> EliminarRegistroDiario(int id)
        {
            var registroDiario = await _context.T_RegistroDiario.FindAsync(id);
            if (registroDiario != null)
            {
                _context.T_RegistroDiario.Remove(registroDiario);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> CrearRegistroDiario(TRegistroDiario registroDiario)
        {
            _context.T_RegistroDiario.Add(registroDiario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarRegistroDiario(TRegistroDiario registroDiario)
        {
            _context.T_RegistroDiario.Update(registroDiario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CrearRegistroDiario(RegistroDiarioCreacionDTO registroDiarioCreacionDTO)
        {
            var registroDiario = new TRegistroDiario
            {
                IdFuncionario = registroDiarioCreacionDTO.IdFuncionario,
                NombreUsuario = registroDiarioCreacionDTO.NombreUsuario,
                UP = registroDiarioCreacionDTO.UP,
                FechaActividad = registroDiarioCreacionDTO.FechaActividad,
                IdDetalleProceso = registroDiarioCreacionDTO.IdDetalleProceso,
                IdActividadMacro = registroDiarioCreacionDTO.IdActividadMacro,
                Observacion = registroDiarioCreacionDTO.Observacion,
                TiempoInvertido = registroDiarioCreacionDTO.TiempoInvertido,
                IdSubArea = registroDiarioCreacionDTO.IdSubArea,
                IdUbicacion = registroDiarioCreacionDTO.IdUbicacion,
                UsuarioIngreso = registroDiarioCreacionDTO.UsuarioIngreso,
                FechaIngreso = registroDiarioCreacionDTO.FechaIngreso
            };

            _context.T_RegistroDiario.Add(registroDiario);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
