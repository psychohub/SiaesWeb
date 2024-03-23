using SiaesLibraryShared.Models.Dtos;

namespace SiaesServer.Repositories.IRepositories
{
    public interface IBitacora
    {
        Task<bool> RegistrarAccion(BitacoraDTO bitacoraDTO);
    }
}
