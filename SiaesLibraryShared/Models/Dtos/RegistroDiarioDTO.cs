using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models.Dtos
{
    public class RegistroDiarioDTO
    {
        public int IdRegistro { get; set; }
        public DateTime FechaActividad { get; set; }
        public string DescripcionProceso { get; set; }
        public string DescripcionSubProceso { get; set; }
        public string DescripcionActividad { get; set; }
        public string DescripcionSubArea { get; set; }
        public string Observacion { get; set; }
        public decimal TiempoInvertido { get; set; }
        public string DescripcionUbicacion { get; set; }
        public string NombreUsuario { get; set; }
        public int UP { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IdSubArea { get; set; } 
        public int IdFuncionario { get; set; } 
    }
}
