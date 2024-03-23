using SiaesLibraryShared.Contracts;
using SiaesLibraryShared.Models.Dtos;
using SiaesLibraryShared.Models;
using SiaesServer.Data;
using SiaesServer.Repositories.IRepositories;


namespace SiaesServer.Repositories
{
    public class BitacoraRepositorio : IBitacora
    {
        private readonly AppDbContext _bd;

        public BitacoraRepositorio(AppDbContext bd)
        {
            _bd = bd;
        }

        public async Task<bool> RegistrarAccion(BitacoraDTO bitacoraDTO)
        {
            try
            {
                var bitacora = new Bitacora
                {
                    UsuarioRegistro = bitacoraDTO.UsuarioRegistro,
                    FechaRegistro = bitacoraDTO.FechaRegistro,
                    Accion = bitacoraDTO.Accion,
                    IdRegistroAfectado = bitacoraDTO.IdRegistroAfectado,
                    NombreTabla = bitacoraDTO.NombreTabla,
                    ValoresAnteriores = bitacoraDTO.ValoresAnteriores,
                    ValoresNuevos = bitacoraDTO.ValoresNuevos,
                    IP = bitacoraDTO.IP,
                    Host = bitacoraDTO.Host,
                    NombreEquipo = bitacoraDTO.NombreEquipo,
                    RemoteIPAddress = bitacoraDTO.RemoteIPAddress,
                    RemoteHostIPAddress = bitacoraDTO.RemoteHostIPAddress,
                    Geolocalizacion = bitacoraDTO.Geolocalizacion
                };

                _bd.Bitacora.Add(bitacora);
                await _bd.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
