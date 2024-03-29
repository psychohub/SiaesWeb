using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class RegistroDiarioCreacionDTO
    {
        public int IdFuncionario { get; set; }
        public string NombreUsuario { get; set; }
        public int UP { get; set; }
        public DateTime FechaActividad { get; set; }
        public int IdProceso { get; set; }
        public int IdSubProceso { get; set; }
        public int IdDetalleProceso { get; set; }
        public int IdActividadMacro { get; set; }
        public string Observacion { get; set; }
        public decimal TiempoInvertido { get; set; }
        public int? IdSubArea { get; set; }
        public int? IdUbicacion { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
