using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class TRegistroDiarioDTO
    {
        public int IdRegistro { get; set; }
        public int IdFuncionario { get; set; }
        public DateTime FechaActividad { get; set; }
        public int IdDetalleProceso { get; set; }
        public int IdActividadMacro { get; set; }
        public string JustificacionRegAtrasado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observacion { get; set; }
        public decimal TiempoInvertido { get; set; }
        public int? IdSubArea { get; set; }
        public int? IdUbicacion { get; set; }
    }
}
