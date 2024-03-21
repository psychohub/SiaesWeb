using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;

namespace SiaesServer.Repositories
{
    public class IEMUsuarioInformeRepositorio : IIEMUsuarioInforme
    {
        private readonly AppDbContext _bd;

    
        public IEMUsuarioInformeRepositorio(AppDbContext bd, IConfiguration config)
        {
            _bd = bd;

        }

        public async Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> descripcionesInforme)
        {
            var usuario = await _bd.Usuario.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
            if (usuario == null)
            {
                return false;
            }

            var establecimiento = await _bd.Establecimientos.FirstOrDefaultAsync(e => e.CodEstablecimiento == codEstablecimiento);
            if (establecimiento == null)
            {
                return false;
            }

            foreach (var descripcionInforme in descripcionesInforme)
            {
                var informe = await _bd.IEMInformes.FirstOrDefaultAsync(i => i.DSC_INFORME == descripcionInforme);
                if (informe != null)
                {
                    var nuevoRegistro = new IEMUsuarioInforme
                    {
                        Usuario = nombreUsuario,
                        COD_INFORME = informe.COD_INFORME, 
                        Cod_Establecimiento = codEstablecimiento,
                        Log_Activo = 1
                    };

                    _bd.IEMUsuariosInformes.Add(nuevoRegistro);
                }
            }

            await _bd.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> descripcionesInforme)
{
    var usuario = await _bd.Usuario.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
    if (usuario == null)
    {
        return false;
    }

    var establecimiento = await _bd.Establecimientos.FirstOrDefaultAsync(e => e.CodEstablecimiento == codEstablecimiento);
    if (establecimiento == null)
    {
        return false;
    }

    var registrosAEliminar = new List<IEMUsuarioInforme>();

    foreach (var descripcionInforme in descripcionesInforme)
    {
        var informe = await _bd.IEMInformes.FirstOrDefaultAsync(i => i.DSC_INFORME == descripcionInforme);
        if (informe != null)
        {
            var registroAEliminar = await _bd.IEMUsuariosInformes
                .FirstOrDefaultAsync(i => i.Usuario == nombreUsuario &&
                                          i.Cod_Establecimiento == codEstablecimiento &&
                                          i.COD_INFORME == informe.COD_INFORME);

            if (registroAEliminar != null)
            {
                registrosAEliminar.Add(registroAEliminar);
            }
        }
    }

    if (registrosAEliminar.Any())
    {
        _bd.IEMUsuariosInformes.RemoveRange(registrosAEliminar);
        await _bd.SaveChangesAsync();
        return true;
    }

    return false;
}

        public async Task<List<IEMUsuarioInforme>> ObtenerInformesAsociados(string nombreUsuario, int codEstablecimiento)
        {
            return await _bd.IEMUsuariosInformes
        .Where(i => i.Usuario == nombreUsuario && i.Cod_Establecimiento == codEstablecimiento)
        .Include(i => i.Informe) 
        .ToListAsync();
        }

        public async Task<IEnumerable<IEMInforme>> ObtenerInformesDisponibles(string nombreUsuario, int codEstablecimiento)
        {
            var informesTotales = await _bd.IEMInformes
         .Where(i => i.Log_Activo == 1 && i.Tipo == 1)
         .ToListAsync();

            var informesAsociados = await _bd.IEMUsuariosInformes
                .Where(i => i.Usuario == nombreUsuario && i.Cod_Establecimiento == codEstablecimiento)
                .Select(i => i.Informe)
                .ToListAsync();

            var informesDisponibles = informesTotales.Except(informesAsociados);

            return informesDisponibles;
        }

        public async Task<IEnumerable<IEMInforme>> ObtenerTodosLosInformes()
        {
            return await _bd.IEMInformes
              .Where(i => i.Log_Activo == 1 && i.Tipo == 1)
              .ToListAsync();
        }
    }
}
