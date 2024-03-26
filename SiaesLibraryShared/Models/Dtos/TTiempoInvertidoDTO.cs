using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class TTiempoInvertidoDTO
    {
        public int IdFuncionario { get; set; }
        public DateTime FechaActividad { get; set; }
        public decimal TiempoInvertido { get; set; }
    }
}
