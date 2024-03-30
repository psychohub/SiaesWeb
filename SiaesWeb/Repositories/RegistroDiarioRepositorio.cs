using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using SiaesLibraryShared.Models.Dtos;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;
using XAct;

namespace SiaesServer.Repositories
{
    public class RegistroDiarioRepositorio : IRegistroDiarioRepositorio
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RegistroDiarioRepositorio(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> EliminarRegistroDiario(RegistroDiarioEliminarDTO dto)
        {
            var registro = await _context.T_RegistroDiario
         .Where(r =>
             r.IdRegistro == dto.IdRegistro &&
             (r.IdFuncionario == dto.IdFuncionario || (r.IdFuncionario == null && dto.IdFuncionario == 0)))
         .Select(r => new { r.IdRegistro, r.IdFuncionario })
         .FirstOrDefaultAsync();

            if (registro == null)
            {
                return false;
            }

            var entidadRegistro = await _context.T_RegistroDiario
                .Where(r => r.IdRegistro == registro.IdRegistro)
                .Select(r => new { r.IdRegistro })
                .FirstOrDefaultAsync();

            if (entidadRegistro != null)
            {
                _context.T_RegistroDiario.Remove(new TRegistroDiario { IdRegistro = entidadRegistro.IdRegistro });
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    

        public async Task<IEnumerable<RegistroDiarioDTO>> ObtenerRegistros(int? IdFuncionario, int? IdSubArea, DateTime FechaActividad, int IdRol)
        {
            var query = _context.T_RegistroDiario
        .Include(rd => rd.DetalleProceso)
            .ThenInclude(dp => dp.Proceso)
        .Include(rd => rd.DetalleProceso)
            .ThenInclude(dp => dp.SubProceso)
        .Include(rd => rd.DetalleProceso)
            .ThenInclude(dp => dp.ActividadSustantiva)
        .Include(rd => rd.SubArea)
        .Include(rd => rd.Ubicacion)
        .Select(rd => new RegistroDiarioDTO
        {
            IdRegistro = rd.IdRegistro,
            FechaActividad = rd.FechaActividad,
            DescripcionProceso = rd.DetalleProceso.Proceso.DescripcionProceso,
            DescripcionSubProceso = rd.DetalleProceso.SubProceso.DescripcionSubProceso,
            DescripcionActividad = rd.DetalleProceso.ActividadSustantiva.DescripcionActividad,
            DescripcionSubArea = rd.SubArea.DescripcionSubArea,
            Observacion = rd.Observacion,
            TiempoInvertido = rd.TiempoInvertido,
            DescripcionUbicacion = rd.Ubicacion.DescripcionUbicacion,
            NombreUsuario = rd.NombreUsuario,
            UP = rd.UP,
            UsuarioIngreso = rd.UsuarioIngreso,
            FechaIngreso = rd.FechaIngreso,
            UsuarioModificacion = rd.UsuarioModificacion,
            FechaModificacion = rd.FechaModificacion,
            IdSubArea = rd.SubArea.IdSubArea,
            IdFuncionario = rd.IdFuncionario 
        });

            // Añadir las condiciones WHERE según el IdRol
            switch (IdRol)
            {
                case 5:
                    query = query.Where(rd => rd.FechaActividad.Date == FechaActividad.Date);
                    break;
                case 4:
                    query = query.Where(rd => rd.IdSubArea == IdSubArea && rd.FechaActividad.Date == FechaActividad.Date);
                    break;
                case 3:
                    query = query.Where(rd => rd.IdFuncionario == IdFuncionario && rd.FechaActividad.Date == FechaActividad.Date);
                    break;
                case 1:
                    query = query.Where(rd => rd.IdFuncionario == IdFuncionario && rd.FechaActividad.Date == FechaActividad.Date);
                    break;
            }

            return await query.ToListAsync();
        }
    }
}
