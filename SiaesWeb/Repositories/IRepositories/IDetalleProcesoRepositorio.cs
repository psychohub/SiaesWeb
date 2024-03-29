namespace SiaesServer.Repositories.IRepositories
{
    public interface IDetalleProcesoRepositorio
    {
        Task<int> ObtenerIdDetalleProceso(int idProceso, int idSubProceso);
    }
}
