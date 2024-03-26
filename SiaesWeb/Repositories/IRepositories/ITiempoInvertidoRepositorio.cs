namespace SiaesServer.Repositories.IRepositories
{
    public interface ITiempoInvertidoRepositorio
    {
        Task<decimal> GetTotalTiempoInvertidoAsync(int idFuncionario, DateTime fechaActividad);
    }
}
