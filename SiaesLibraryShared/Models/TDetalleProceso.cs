using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiaesLibraryShared.Models
{
    public class TDetalleProceso
    {
        [Key]
        public int IdDetalleProceso { get; set; }

        [Required]
        public int IdProceso { get; set; }

        [Required]
        public int IdSubProceso { get; set; }

        [Required]
        public int IdActividad { get; set; }

        // Propiedades de navegación
        public virtual TProceso Proceso { get; set; }
        public virtual TSubProceso SubProceso { get; set; }
        public virtual TActividadSustantiva ActividadSustantiva { get; set; }
        public virtual ICollection<TDetalleProcesoSubArea> DetallesProcesosSubAreas { get; set; }
        public virtual ICollection<TRegistroDiario> RegistrosDiarios { get; set; }
    }
}
