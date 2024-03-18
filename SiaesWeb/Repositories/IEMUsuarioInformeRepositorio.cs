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

        public async Task<bool> AsociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
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

            foreach (var codigoInforme in codigosInforme)
            {
                var informe = await _bd.IEMInformes.FirstOrDefaultAsync(i => i.COD_INFORME == codigoInforme);
                if (informe != null)
                {
                    var nuevoRegistro = new IEMUsuarioInforme
                    {
                        Usuario = nombreUsuario,
                        COD_INFORME = codigoInforme,
                        Cod_Establecimiento = codEstablecimiento,
                        Log_Activo = 1
                    };
                    _bd.IEMUsuariosInformes.Add(nuevoRegistro);
                }
            }

            await _bd.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DesasociarInformes(string nombreUsuario, int codEstablecimiento, List<string> codigosInforme)
        {
            var registrosAEliminar = await _bd.IEMUsuariosInformes
       .Where(i => i.Usuario == nombreUsuario && i.Cod_Establecimiento == codEstablecimiento && codigosInforme.Contains(i.COD_INFORME))
       .ToListAsync();

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
    }
}
