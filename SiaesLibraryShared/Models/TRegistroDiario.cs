using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class TRegistroDiario
    {
        [Key]
          public int IdRegistro { get; set; }

        [Required]
        public int IdFuncionario { get; set; }

        [Required]
        public DateTime FechaActividad { get; set; }

        [Required]
        public int IdDetalleProceso { get; set; }

        [Required]
        public int IdActividadMacro { get; set; }

        [Required]
        [StringLength(150)]
        public string JustificacionRegAtrasado { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        [StringLength(500)]
        public string Observacion { get; set; }

        [Required]
        public decimal TiempoInvertido { get; set; }

        public int? IdSubArea { get; set; }

        public int? IdUbicacion { get; set; }

        // Propiedades de navegación
        public virtual TDetalleProceso DetalleProceso { get; set; }
        public virtual TActividadMacro ActividadMacro { get; set; }
        public virtual TUbicacion Ubicacion { get; set; }
        public virtual SubArea SubArea { get; set; }
    }
}
