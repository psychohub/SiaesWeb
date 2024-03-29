using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Contracts
{
    public interface IServicioTiempoInvertidoServicio
    {
        Task<decimal> GetTotalTiempoInvertidoAsync(int idFuncionario, DateTime fechaActividad);
    }
}

